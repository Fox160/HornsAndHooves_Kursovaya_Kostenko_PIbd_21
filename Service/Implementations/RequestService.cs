using System;
using System.Collections.Generic;
using System.Linq;
using Service.BindingModels;
using Service.Interfaces;
using Service.ViewModels;
using System.Data.Entity.SqlServer;
using Models;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace Service.Implementations
{
    public class RequestService : IRequestService
    {
        private DBContext context;

        public RequestService(DBContext context)
        {
            this.context = context;
        }

        public List<RequestViewModel> GetList()
        {
            return context.Requests
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

        public RequestViewModel GetElement(int id)
        {
            Request request = context.Requests.FirstOrDefault(rec => rec.Id == id);
            if (request != null)
            {
                return new RequestViewModel
                {
                    Id = request.Id,
                    Price = request.Price,
                    Date = request.Date.ToString(),
                    RequestProducts = context.RequestProducts
                            .Where(recPC => recPC.RequestId == request.Id)
                            .Select(recPC => new RequestProductViewModel
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
                };
            }
            throw new Exception("Заявка не найдена");
        }

        public void AddElement(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Request request = context.Requests.FirstOrDefault(rec => rec.Date == model.Date);
                    if (request != null)
                        throw new Exception("Такой запрос уже существует");

                    request = new Request
                    {
                        Price = model.Price,
                        Date = model.Date
                    };
                    context.Requests.Add(request);
                    context.SaveChanges();

                    var groupProducts = model.RequestProducts
                        .GroupBy(rec => rec.ProductId)
                        .Select(rec => new
                            {
                                ProductId = rec.Key,
                                Count = rec.Sum(r => r.Count)
                            }
                        );

                    foreach (var groupProduct in groupProducts)
                    {
                        context.RequestProducts.Add(
                            new RequestProduct
                            {
                                RequestId = request.Id,
                                ProductId = groupProduct.ProductId,
                                Count = groupProduct.Count
                            }
                        );
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void SaveRequestToExcelFile(RequestViewModel model, string fileName)
        {
            var excel = new Application();
            try
            {
                if (File.Exists(fileName))
                {
                    excel.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(fileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;

                var excelworksheet = (Worksheet)excelsheets.get_Item(1);

                excelworksheet.Cells.Clear();

                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;

                Range excelcells = excelworksheet.get_Range("A1", "B1");
                excelcells.Merge(Type.Missing);

                excelcells.Font.Bold = true;
                excelcells.Value2 = "Запрос на продукты";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("A2", "B2");
                excelcells.Merge(Type.Missing);

                excelcells.Font.Bold = true;
                excelcells.Value2 = "на " + model.Date;
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("B1", "B1");
                excelcells = excelcells.get_Offset(3, -1);
                excelcells.ColumnWidth = 15;
                excelcells.Value2 = "Продукт";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                excelcells = excelcells.get_Offset(0, 1);
                excelcells.ColumnWidth = 15;
                excelcells.Value2 = "Количество";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                excelcells = excelcells.get_Offset(0, 1);
                excelcells.ColumnWidth = 15;
                excelcells.Value2 = "Цена";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                double totalSum = 0;

                var dict = model.RequestProducts;
                if (dict != null)
                {
                    excelcells = excelworksheet.get_Range("A4", "A4");

                    
                    foreach (var elem in dict)
                    {
                        double productSum = elem.Count * elem.ProductPrice;
                        totalSum += productSum;


                        var excelBorder =
                            excelworksheet.get_Range(excelcells, excelcells.get_Offset(dict.Count, 2));
                        excelBorder.Borders.LineStyle = XlLineStyle.xlContinuous;
                        excelBorder.Borders.Weight = XlBorderWeight.xlThin;
                        excelBorder.HorizontalAlignment = Constants.xlCenter;
                        excelBorder.VerticalAlignment = Constants.xlCenter;
                        excelBorder.BorderAround(XlLineStyle.xlContinuous,
                                                XlBorderWeight.xlMedium,
                                                XlColorIndex.xlColorIndexAutomatic, 1);

                        excelcells = excelcells.get_Offset(1, 0);
                        excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Times New Roman";
                        excelcells.Font.Size = 12;
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.ProductName;

                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Times New Roman";
                        excelcells.Font.Size = 12;
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.Count;

                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Times New Roman";
                        excelcells.Font.Size = 12;
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.ProductPrice;
                        excelcells = excelcells.get_Offset(1, -2);

                        excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Times New Roman";
                        excelcells.Font.Size = 12;
                        excelcells.Font.Bold = true;
                        excelcells.Value2 = "Итого";

                        excelcells = excelcells.get_Offset(0, 2);
                        excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Times New Roman";
                        excelcells.Font.Size = 12;
                        excelcells.Font.Bold = true;
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = productSum.ToString();

                        excelcells = excelcells.get_Offset(1, -2);

                    }
                }
                excelcells = excelcells.get_Offset(1, 0);
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Итого";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                excelcells = excelcells.get_Offset(0, 2);
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Bold = true;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;
                excelcells.Value2 = totalSum;

                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excel.Quit();
            }
        }

        public void SaveRequestToWordFile(RequestViewModel model, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;

                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;

                range.Text = "Запрос на продукты на " + model.Date;

                range.InsertParagraphAfter();

                var requestProducts = model.RequestProducts;
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, requestProducts.Count + 1, 4, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                table.Cell(1, 1).Range.Text = "Продукт";
                table.Cell(1, 2).Range.Text = "Количество";
                table.Cell(1, 3).Range.Text = "Цена";
                table.Cell(1, 4).Range.Text = "Цена за продукт";

                double totalSum = 0;

                for (int i = 0; i < requestProducts.Count; ++i)
                {
                    double productSum = requestProducts[i].Count * requestProducts[i].ProductPrice;
                    totalSum += productSum;

                    table.Cell(i + 2, 1).Range.Text = requestProducts[i].ProductName;
                    table.Cell(i + 2, 2).Range.Text = requestProducts[i].Count.ToString();
                    table.Cell(i + 2, 3).Range.Text = requestProducts[i].ProductPrice.ToString();
                    table.Cell(i + 2, 4).Range.Text = productSum.ToString();
                }

                table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;

                range.Text = "Итого: " + totalSum.ToString();

                font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;

                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;

                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;

                range.InsertParagraphAfter();

                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(filename, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }
    }
}
