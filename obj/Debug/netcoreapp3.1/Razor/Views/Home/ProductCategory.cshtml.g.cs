#pragma checksum "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b9beb7bf0164c71feea2507bd50016b34a85541"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductCategory), @"mvc.1.0.view", @"/Views/Home/ProductCategory.cshtml")]
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
#line 1 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\_ViewImports.cshtml"
using frame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\_ViewImports.cshtml"
using frame.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b9beb7bf0164c71feea2507bd50016b34a85541", @"/Views/Home/ProductCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
  
    ViewData["Title"] = "Product Category";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var BookNotDis = ViewBag.BookNotDis;
    var BookDis = ViewBag.BookDis;
    var NameCategory = ViewBag.NameCategory;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"content clearfix\">\r\n    <div class=\"page-header page-header-product\">\r\n        <div class=\"container\">\r\n            <h1>Cửa Hàng</h1>\r\n            <ul class=\"breadcrumb\">\r\n                <li class=\"breadcrumb-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b9beb7bf0164c71feea2507bd50016b34a855414084", async() => {
                WriteLiteral("Trang Chủ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li class=\"breadcrumb-item active\">\r\n");
#nullable restore
#line 17 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                     foreach(var item in NameCategory) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <strong>");
#nullable restore
#line 18 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                           Write(item.nameCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n");
#nullable restore
#line 19 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </li>
            </ul>
        </div>
    </div>
</div>
<div class=""ads-grid py-sm-5 py-4"">
    <div class=""container py-xl-4 py-lg-2"">
        <div class=""row"">
            <!-- product left -->
            <div class=""agileinfo-ads-display col-lg-12"">
                <div class=""wrapper"">
                    <!-- first section -->
");
#nullable restore
#line 32 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                     if(BookDis.Count != 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"product-sec1 px-sm-4 px-3 py-sm-5  py-3 mb-4\">\r\n                        <h3 class=\"heading-tittle text-center font-italic\">\r\n                            Sách Khuyến Mãi\r\n                        </h3><div class=\"row\">\r\n");
#nullable restore
#line 37 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                             foreach(var item in BookDis) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-md-3 product-men mt-5"">
                                <div class=""men-pro-item simpleCart_shelfItem"">
                                    <div class=""men-thumb-item text-center"">
                                        <img");
            BeginWriteAttribute("src", " src=\"", 1717, "\"", 1749, 2);
            WriteAttributeValue("", 1723, "../../images/", 1723, 13, true);
#nullable restore
#line 41 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 1736, item.imgBook, 1736, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1750, "\"", 1770, 1);
#nullable restore
#line 41 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 1756, item.nameBook, 1756, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                        widtd= '194px' height='300px'>
                                        <div class=""men-cart-pro"">
                                            <div class=""inner-men-cart-pro"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 2041, "\"", 2085, 2);
            WriteAttributeValue("", 2048, "../../Home/DetailProduct/", 2048, 25, true);
#nullable restore
#line 45 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 2073, item.idBook, 2073, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" 
                                                class=""link-product-add-cart"">Xem</a>
                                            </div>
                                        </div>
                                        <span class=""product-new-top"">-");
#nullable restore
#line 49 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                                  Write(item.numberDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                    <div class=""item-info-product text-center border-top mt-4"">
                                        <h4 class=""pt-1"">
                                            <a href=""#"">");
#nullable restore
#line 53 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                   Write(item.nameBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </h4>\r\n                                        <div class=\"info-product-price my-2\">\r\n                                            <span class=\"item_price\">\r\n                                                $");
#nullable restore
#line 57 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                             Write(item.priceBook - item.priceBook*item.numberDiscount/100);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </span>\r\n                                            <del>$");
#nullable restore
#line 59 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                             Write(item.priceBook);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</del>
                                        </div>
                                        <div class=""snipcart-details add-to-cart top_brand_home_details item_add single-item hvr-outline-out"">
                                            <a class=""button btn""
                                            data-name='");
#nullable restore
#line 63 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                  Write(item.nameBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n                                            data-price = \'");
#nullable restore
#line 64 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                     Write(item.priceBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' \r\n                                            data-number = \'");
#nullable restore
#line 65 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                      Write(item.numberDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n                                            data-image= \'");
#nullable restore
#line 66 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                    Write(item.imgBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'");
            BeginWriteAttribute("id", "\r\n                                            id=\"", 3646, "\"", 3708, 1);
#nullable restore
#line 67 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 3696, item.idBook, 3696, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Thêm vào giỏ hàng</a>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 72 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                            }                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 75 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!-- //first section -->
                    <!-- second section -->
                    <div class=""product-sec1 px-sm-4 px-3 py-sm-5  py-3 mb-4"">
                        <h3 class=""heading-tittle text-center font-italic"">Sách theo thể loại</h3>
                        <div class=""row"">
");
#nullable restore
#line 81 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                             foreach(var item in BookNotDis) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-md-3 product-men mt-5"">
                                <div class=""men-pro-item simpleCart_shelfItem"">
                                    <div class=""men-thumb-item text-center"">
                                        <img");
            BeginWriteAttribute("src", " src=\"", 4693, "\"", 4725, 2);
            WriteAttributeValue("", 4699, "../../images/", 4699, 13, true);
#nullable restore
#line 85 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 4712, item.imgBook, 4712, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4726, "\"", 4746, 1);
#nullable restore
#line 85 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 4732, item.nameBook, 4732, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" 
                                        widtd= '194px' height='300px' style=""width:194px"">
                                        <div class=""men-cart-pro"">
                                            <div class=""inner-men-cart-pro"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 5038, "\"", 5082, 2);
            WriteAttributeValue("", 5045, "../../Home/DetailProduct/", 5045, 25, true);
#nullable restore
#line 89 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 5070, item.idBook, 5070, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""link-product-add-cart"">Xem</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""item-info-product text-center border-top mt-4"">
                                        <h4 class=""pt-1"">
                                            <a href=""#"">");
#nullable restore
#line 95 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                   Write(item.nameBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </h4>\r\n                                        <div class=\"info-product-price my-2\">\r\n                                            <span class=\"item_price\">\r\n                                                $");
#nullable restore
#line 99 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                             Write(item.priceBook);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </span>
                                        </div>
                                        <div class=""snipcart-details add-to-cart top_brand_home_details item_add single-item hvr-outline-out"">
                                            <a class=""button btn""
                                            data-name='");
#nullable restore
#line 104 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                  Write(item.nameBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n                                            data-price = \'");
#nullable restore
#line 105 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                     Write(item.priceBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' \r\n                                            data-number = \'0\'\r\n                                            data-image= \'");
#nullable restore
#line 107 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                                                    Write(item.imgBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'");
            BeginWriteAttribute("id", "\r\n                                            id=\"", 6359, "\"", 6421, 1);
#nullable restore
#line 108 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
WriteAttributeValue("", 6409, item.idBook, 6409, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Thêm vào giỏ hàng</a>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 113 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Home\ProductCategory.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            \r\n                        </div>\r\n                    </div>\r\n                    <!-- //second section -->\r\n                </div>\r\n            </div>\r\n            <!-- //product left -->\r\n        </div>\r\n    </div>\r\n</div>");
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
