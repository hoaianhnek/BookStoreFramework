#pragma checksum "C:\xampp\htdocs\frame\Views\Home\Information.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Information), @"mvc.1.0.view", @"/Views/Home/Information.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb", @"/Views/Home/Information.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Information : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<frame.Models.Customer>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
  
    ViewData["Title"] = "Check out";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var detailinfo = ViewBag.detailinfo;
    var email = ViewBag.Email;
    var city = ViewBag.city;
    var citylist = ViewBag.cityList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
 if(TempData["StatusUpdate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-success alert-dismissible\">\r\n    <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n    ");
#nullable restore
#line 13 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
Write(TempData["StatusUpdate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 15 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <div class=\"container\">\r\n        <h1>Account Information</h1>\r\n        <ul class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb4771", async() => {
                WriteLiteral("Home");
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
            WriteLiteral(@"
            </li>
            <li class=""breadcrumb-item active"">
                <strong>Account Information</strong>
            </li>
        </ul>
    </div>
</div>
<div class=""ads-grid py-sm-5 py-4"">
    <div class=""container py-xl-4 py-lg-2"">
        <!-- tittle heading -->
        <h3 class=""tittle-w3l text-center mb-lg-5 mb-sm-4 mb-3"">
            <span>Account Information</span></h3>
        <!-- //tittle heading -->
        <div class=""row"">
            <!-- product right -->
            <div class=""col-lg-3 mt-lg-0 mt-4 p-lg-0"">
                <div class=""side-bar p-sm-4 p-3"">
                    <div class=""search-hotel border-bottom py-2"">
                        <div class=""d-flex"">
                            <img src=""../../images/avatar.png"" style=""border-radius: 50%;
                                height: 45px;
                                width: 45px;""/>
");
#nullable restore
#line 45 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                             foreach (var item in detailinfo)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"ml-3\">\r\n                                <h3 class=\"agileits-sear-head mb-1\">Account of</h3>\r\n                                <span>");
#nullable restore
#line 49 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                 Write(item.nameCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n");
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            
                            
                        </div>
                        
                        <div class=""left-side py-2"">
                            <ul style=""list-style-type:none"">
                                <li>
                                    <i class=""fas fa-user""></i>
                                    <a href=""Information""><span class=""span"">Account Information</span></a>
                                </li>
                                <li>
                                    <i class=""far fa-address-book""></i>
                                    <a href=""InformationMyself""><span class=""span"">Order Management</span></a>
                                </li>
                                <li>
                                    <i class=""fas fa-sign-out-alt""></i>
                                    <a href=""/Home/Logout""><span class=""span"">Logout</span></a>
                                </li>
                            <");
            WriteLiteral(@"/ul>
                        </div>
                    </div>
                </div>
                <!-- //product right -->
            </div>
            <!-- product left -->
            <div class=""agileinfo-ads-display col-lg-9"">
                <div class=""wrapper"">
                    <!-- first section -->
                    <div class=""product-sec1 px-sm-4 px-3 py-sm-5  py-3 mb-4"">
                        <div class=""row"">
                            <div class=""checkout-right"">
");
#nullable restore
#line 83 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                 foreach (var item in detailinfo)
                                {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                 using (Html.BeginForm("Information","Home",new {@class = "creditly-card-form agileinfo_form"}))
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                            ;
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                               Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                   <div class=""creditly-wrapper wthree, w3_agileits_wrapper"">
                                        <div class=""information-wrapper"">
                                            <div class=""first-row"">
                                                <label class=""input-label"">Full Name</label>
                                                <div class=""controls form-group w-100"">
                                                    <input class=""billing-address-name form-control"" pattern=""^[A-Za-z\s]*"" title=""Full name should without accents"" type=""text"" name=""nameCustomer"" maxlength=""128"" 
                                                    placeholder=""Truong Thi Hoai Anh""");
            BeginWriteAttribute("required", " required=\"", 4655, "\"", 4666, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 4667, "\"", 4693, 1);
#nullable restore
#line 95 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
WriteAttributeValue("", 4675, item.nameCustomer, 4675, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                </div>
                                                <label class=""input-label"">Phone</label>
                                                <div class=""w3_agileits_card_number_grids"">
                                                    <div class=""w3_agileits_card_number_grid_left form-group"">
                                                        <div class=""controls w-100"">
                                                            <input type=""text"" class=""form-control"" placeholder=""0977667321""
                                                            name=""phoneCustomer""");
            BeginWriteAttribute("required", " required=\"", 5340, "\"", 5351, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5352, "\"", 5379, 1);
#nullable restore
#line 102 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
WriteAttributeValue("", 5360, item.phoneCustomer, 5360, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        ");
#nullable restore
#line 103 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.idCustomer,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </div>
                                                    </div>
                                                    <label class=""input-label"">Email</label>
                                                    <div class=""w3_agileits_card_number_grid_right form-group"">
                                                        <div class=""controls w-100"">
                                                            <input type=""text"" class=""form-control"" placeholder=""a@gmail.com"" 
                                                            name=""email""");
            BeginWriteAttribute("required", " required=\"", 6143, "\"", 6154, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6155, "\"", 6169, 1);
#nullable restore
#line 110 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
WriteAttributeValue("", 6163, email, 6163, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                                                        </div>
                                                    </div>
                                                </div>
                                                <label class=""input-label"">City</label>
                                                <div class=""controls form-group w-100"">
                                                    <select class=""option-w3ls"" name=""idShip"">
");
#nullable restore
#line 117 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                         foreach (var c in city)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb15212", async() => {
#nullable restore
#line 119 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                                 Write(c.country);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                               WriteLiteral(c.idShip);

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
#line 120 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                             foreach (var list in citylist)
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                 if(list.idShip != c.idShip){

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb17708", async() => {
#nullable restore
#line 123 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                                        Write(list.country);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 123 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                   WriteLiteral(list.idShip);

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
#line 124 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                 
                                                                
                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 126 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                             
                                                            
                                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                         if(item.idShip == "") {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb20697", async() => {
                WriteLiteral("Select City");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 131 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                             foreach (var list in citylist)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5110e1e8e7e1a6f93f339150d84e3f6d9ba87ccb22046", async() => {
#nullable restore
#line 133 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                                        Write(list.country);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 133 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                                   WriteLiteral(list.idShip);

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
#line 134 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                                             
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    </select>
                                                </div>
                                                <label class=""input-label"">Address</label>
                                                <div class=""controls form-group w-100"">
                                                    <input type=""text"" class=""form-control"" placeholder=""Address"" 
                                                    name=""addressCustomer"" pattern=""^[A-Za-z0-9-\s]*"" title=""Address should without accents""");
            BeginWriteAttribute("required", " required=\"", 8692, "\"", 8703, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 8704, "\"", 8733, 1);
#nullable restore
#line 141 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
WriteAttributeValue("", 8712, item.addressCustomer, 8712, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                </div>
                                                
                                            </div>
                                            <button class=""submit check_out btn"">Update</button>
                                            <input class=""billing-address-name form-control d-none"" type=""text"" name=""idCustomer"" maxlength=""128"" 
                                                placeholder=""Full Name""");
            BeginWriteAttribute("required", " required=\"", 9212, "\"", 9223, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 9224, "\"", 9248, 1);
#nullable restore
#line 147 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
WriteAttributeValue("", 9232, item.idCustomer, 9232, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        </div>\r\n                                    </div> \r\n");
#nullable restore
#line 150 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\xampp\htdocs\frame\Views\Home\Information.cshtml"
                                 
                                    
                                
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                
                                
                                
                                
                                
                            </div>
                        </div>
                    </div>
                    <!-- //first section -->
                </div>
            </div>
            <!-- //product left -->
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<frame.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
