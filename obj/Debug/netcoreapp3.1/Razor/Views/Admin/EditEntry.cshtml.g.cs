#pragma checksum "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf4268a7f3c75b659a295546776f564a7b05dce5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditEntry), @"mvc.1.0.view", @"/Views/Admin/EditEntry.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\xampp\htdocs\frame\Views\_ViewImports.cshtml"
using frame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\frame\Views\_ViewImports.cshtml"
using frame.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf4268a7f3c75b659a295546776f564a7b05dce5", @"/Views/Admin/EditEntry.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditEntry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
  
    ViewBag.Title = "Add Customer";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    var entry = ViewBag.entry;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
  
    var sessionName = new Byte[20];
    bool ok = Context.Session.TryGetValue("login", out sessionName);
    string result = "";
    User users = null;
    if (ok)
    {
        result = System.Text.Encoding.UTF8.GetString(sessionName);
        users = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(result);
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
 if(users == null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5 class=\"text-danger mt-5 d-flex justify-content-center\">Bạn không có quyền vào trang này. Vui lòng <a class=\"text-light ml-1\"href=\"../../Admin/AccountAdmin\"> đăng nhập</a></h5>\r\n");
#nullable restore
#line 19 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
} else {  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""right_col"" role=""main"">
    <div class=""EditCategory"">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>QUẢN LÝ PHIẾU NHẬP</h4>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>Sửa Phiếu Nhập</h2>
                        <div class=""clearfix""></div>
                    </div>
");
#nullable restore
#line 35 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""form-row"">
                            <div class=""form-group col-md-2"">
                                <label class=""font-weight-bold"">Số PN</label>
                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 1745, "\"", 1767, 1);
#nullable restore
#line 42 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 1753, entry.idEntry, 1753, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1832, "\"", 1854, 1);
#nullable restore
#line 43 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 1840, entry.idEntry, 1840, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""idEntry""/>
                            </div> 
                            <div class=""form-group col-md-5"">
                                <label class=""font-weight-bold"">Tên NCC</label>
                                <select class=""form-control m-bot15"" name=""idSupplier"">
");
#nullable restore
#line 48 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                     foreach (var item in  ViewBag.suppliers)
                                    {
                                        if(item.idSupplier == entry.idSupplier) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf4268a7f3c75b659a295546776f564a7b05dce57517", async() => {
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                                        Write(item.nameSupplier);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                               WriteLiteral(item.idSupplier);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 52 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf4268a7f3c75b659a295546776f564a7b05dce59575", async() => {
#nullable restore
#line 53 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                                        Write(item.nameSupplier);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                               WriteLiteral(item.idSupplier);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    
                                </select>
                            </div>
                            <div class=""form-group col-md-5"">
                                <label class=""font-weight-bold"">Ngày lập</label>
                                <input type=""date"" class=""form-control"" name=""dateEntry""");
            BeginWriteAttribute("value", " value=\'", 3039, "\'", 3086, 1);
#nullable restore
#line 61 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 3047, entry.dateEntry.ToString("yyyy-MM-dd"), 3047, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required>\r\n                                <div class=\"text-danger\">");
#nullable restore
#line 62 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                    Write(TempData["errorDate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""form-group col-md-4"">
                                <div class=""form-row"">
                                    <div class=""form-group col-md-12"">
                                        <label class=""font-weight-bold"">Tên sách</label>
                                        <select class=""form-control m-bot15 optionBook"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf4268a7f3c75b659a295546776f564a7b05dce513216", async() => {
                WriteLiteral("--Chọn sách--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 72 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                             foreach(var item in ViewBag.books) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf4268a7f3c75b659a295546776f564a7b05dce514673", async() => {
#nullable restore
#line 73 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                                    Write(item.nameBook);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                               WriteLiteral(item.idBook);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 74 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </select>
                                    </div>
                                </div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label class=""font-weight-bold"">Số lượng</label>
                                        <input type=""number"" class=""form-control quantity"" placeholder=""Nhập số lượng"">
                                    </div>
                                    <div class=""form-group col-md-6"">
                                        <label class=""font-weight-bold"">Giá</label>
                                        <input type=""number"" class=""form-control priceBook"" placeholder=""Nhập giá"">
                                    </div>
                                </div>
                                <br>
                                <div class=""modal-footer"">
                                    <a href=""../../A");
            WriteLiteral(@"dmin/EntryManagement"" name=""submit-cancel"" class=""btn btn-danger"">Hủy</a>
                                    <input type=""submit"" name=""submit-save"" class=""btn btn-success"" value=""Lưu"" />
                                </div>
                            </div>
                            <div class=""form-group col-md-1 pl-5"">
                                <a class=""btn bg-success mt-5 text-light btnAddEntry"" style=""cursor: pointer;"">Thêm sách</a>
                            </div>
                            <div class=""form-group col-md-7 pl-5"" style=""height:240px;overflow-y:scroll"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>Tên sách</th>
                                            <th>Số lượng</th>
                                            <th>Giá</th>
                                            <th>Hành động</th>
                          ");
            WriteLiteral("              </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 108 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                         foreach (var item in ViewBag.detail)
                                        {
                                            if(item.idEntry == entry.idEntry) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n");
#nullable restore
#line 113 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                     foreach (var b in ViewBag.books)
                                                    {
                                                        if(item.idBook == b.idBook) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <input type=\'text\'");
            BeginWriteAttribute("value", " value=\'", 6760, "\'", 6779, 1);
#nullable restore
#line 116 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 6768, b.nameBook, 6768, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\'name\' class=\'border-0\' disabled/>\r\n");
#nullable restore
#line 117 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                        }
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                                <input type=\'hidden\'");
            BeginWriteAttribute("value", " value=\'", 7059, "\'", 7079, 1);
#nullable restore
#line 120 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 7067, item.idBook, 7067, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\'id\' />\r\n                                                <td><input type=\'text\'");
            BeginWriteAttribute("value", " value=\'", 7165, "\'", 7192, 1);
#nullable restore
#line 121 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 7173, item.quantityEntry, 7173, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 7193, "\"", 7219, 2);
            WriteAttributeValue("", 7198, "quantity-", 7198, 9, true);
#nullable restore
#line 121 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 7207, item.idBook, 7207, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\'amount\' class=\'w-100 border-0\'/></td>\r\n                                                <td><input type=\'text\'");
            BeginWriteAttribute("value", " value=\'", 7336, "\'", 7360, 1);
#nullable restore
#line 122 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
WriteAttributeValue("", 7344, item.priceEntry, 7344, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("name=\'price\' id=\"price@item.priceEntry\" class=\'w-100 border-0\'/></td>\r\n                                            </tr> \r\n");
#nullable restore
#line 124 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                                <div class=\"text-danger\">");
#nullable restore
#line 128 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                                                    Write(TempData["errordetail"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div> \r\n                        </div> \r\n");
#nullable restore
#line 131 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 137 "C:\xampp\htdocs\frame\Views\Admin\EditEntry.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
