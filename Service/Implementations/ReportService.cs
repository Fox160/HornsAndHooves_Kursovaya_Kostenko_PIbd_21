using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.BindingModels;
using Service.Interfaces;
using Service.ViewModels;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Service.Implementations
{
    public class ReportService : IReportService
    {
        private DBContext context;

        public ReportService(DBContext context)
        {
            this.context = context;
        }

        public List<OrderViewModel> GetOrdersList(ReportBindingModel model)
        {
            return context.Orders
                .Where(rec => rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                .Select(
                    rec => new OrderViewModel
                    {
                        ClientName = rec.Client.Name,
                        Date = rec.Date.ToString(),
                        IsCompleted = rec.IsCompleted,
                        Price = rec.OrderDishes.Sum(r => r.Price)
                    }
                )
                .ToList();
        }

        public List<RequestViewModel> GetRequestsList(ReportBindingModel model)
        {
            return context.Requests
                .Where(rec => rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    Price = rec.Price,
                    Date = rec.Date.ToString(),
                    RequestProducts = context.RequestProducts
                            .Where(recPR => recPR.RequestId == rec.Id)
                            .Select(
                                recPC => new RequestProductViewModel
                                {
                                    Id = recPC.Id,
                                    RequestId = recPC.RequestId,
                                    ProductId = recPC.ProductId,
                                    ProductName = recPC.Product.Name,
                                    ProductPrice = recPC.Product.Price,
                                    Count = recPC.Count
                                }
                            )
                            .ToList()
                })
                .ToList();
        }

        public void SaveReportToFile(ReportBindingModel model)
        {
            //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }

            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);

            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //вставляем заголовок
            var phraseTitle = new Phrase("Отчеты",
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString() +
                                    " по " + model.DateTo.Value.ToShortDateString(),
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);


            var phraseOrders = new Phrase("Отчет по заказам",
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseOrders)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(3)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160 });

            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("Дата", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Имя клиента", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Цена", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //заполняем таблицу
            var list = GetOrdersList(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {
                cell = new PdfPCell(new Phrase(list[i].Date, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].ClientName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Price.ToString(), fontForCells));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
            }

            //вставляем итого
            var phraseOrdersSum = new Phrase("Итого: " + list.Sum(rec => rec.Price).ToString(),
                                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseOrdersSum)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            /*cell = new PdfPCell(new Phrase("Итого: ", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 4,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(list.Sum(rec => rec.Price).ToString(), fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("", fontForCellBold))
            {
                Border = 0
            };
            table.AddCell(cell);*/

            //вставляем таблицу
            doc.Add(table);

            //Отчет по заявкам
            var phraseRequests = new Phrase("Отчет по заявкам",
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseRequests)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable tableRequests = new PdfPTable(2)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160 });

            //вставляем шапку
            PdfPCell cellRequest = new PdfPCell();
            tableRequests.AddCell(new PdfPCell(new Phrase("Дата", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            tableRequests.AddCell(new PdfPCell(new Phrase("Цена", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //заполняем таблицу
            var listRequest = GetRequestsList(model);
            for (int i = 0; i < listRequest.Count; i++)
            {
                cellRequest = new PdfPCell(new Phrase(listRequest[i].Date, fontForCells));
                tableRequests.AddCell(cellRequest);
                cellRequest = new PdfPCell(new Phrase(listRequest[i].Price.ToString(), fontForCells));
                tableRequests.AddCell(cellRequest);
            }

            //вставляем итого
            var phraseRequestsSum = new Phrase("Итого: " + listRequest.Sum(rec => rec.Price).ToString(),
                                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseRequestsSum)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            /*cellRequest = new PdfPCell(new Phrase("Итого:", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 4,
                Border = 0
            };
            tableRequests.AddCell(cellRequest);
            cellRequest = new PdfPCell(new Phrase(listRequest.Sum(rec => rec.Price).ToString(), fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            tableRequests.AddCell(cellRequest);
            cellRequest = new PdfPCell(new Phrase("", fontForCellBold))
            {
                Border = 0
            };
            tableRequests.AddCell(cellRequest);*/
            //вставляем таблицу
            doc.Add(tableRequests);

            doc.Close();
        }
    }
}
