#pragma checksum "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a6537085cf03673a23f1e3bc0d2745a373c9ed4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditAuthor), @"mvc.1.0.view", @"/Views/Admin/EditAuthor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a6537085cf03673a23f1e3bc0d2745a373c9ed4", @"/Views/Admin/EditAuthor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditAuthor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<frame.Models.Author>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n");
#nullable restore
#line 3 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
  
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    var name = ViewBag.name;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
  
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
#line 18 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
 if(users == null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5 class=\"text-danger mt-5 d-flex justify-content-center\">Bạn không có quyền vào trang này. Vui lòng <a class=\"text-light ml-1\"href=\"../../Admin/AccountAdmin\"> đăng nhập</a></h5>\r\n");
#nullable restore
#line 20 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
} else {  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""right_col"" role=""main"">
    <div class=""EditCategory"">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>QUẢN LÝ TÁC GIẢ</h4>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>Sửa Tác Giả</h2>
                        <div class=""clearfix""></div>
                    </div>
");
#nullable restore
#line 36 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""form-row""> 
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">Mã</label>
                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 1729, "\"", 1751, 1);
#nullable restore
#line 43 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
WriteAttributeValue("", 1737, name.idAuthor, 1737, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1816, "\"", 1838, 1);
#nullable restore
#line 44 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
WriteAttributeValue("", 1824, name.idAuthor, 1824, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""idAuthor""/>
                            </div> 
                            <div class=""form-group col-md-6"">
                                <div class=""form-group col-md-4"">
                                    <label class=""font-weight-bold"">Hình ảnh</label>
                                    <input type=""file"" class=""form-control hinhanhsach border-0"" name=""imgAuthor"" id=""image""");
            BeginWriteAttribute("value", " value=\"", 2236, "\"", 2244, 0);
            EndWriteAttribute();
            WriteLiteral("/>\r\n                                </div>\r\n                                <div class=\"form-group col-md-5\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 2396, "\"", 2430, 2);
            WriteAttributeValue("", 2402, "../../images/", 2402, 13, true);
#nullable restore
#line 52 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
WriteAttributeValue("", 2415, name.imgAuthor, 2415, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id = ""show-image"" width=""auto""
                                    height=""90px"">
                                </div>
                            </div>
                        </div>  
                        <div class=""form-row"">
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">Tên tác giả</label>
                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("required", " required=\"", 2893, "\"", 2904, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2905, "\"", 2929, 1);
#nullable restore
#line 60 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
WriteAttributeValue("", 2913, name.nameAuthor, 2913, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"name=""nameAuthor"" placeholder=""Nhập tên tác giả"">
                            </div>   
                        </div>
                        <div class=""form-row"">
                            <div class=""form-group col-md-6"">
                                <label class=""col-form-label font-weight-bold des"">Mô tả</label>
                                <textarea class=""form-control des""");
            BeginWriteAttribute("required", "required=\"", 3327, "\"", 3337, 0);
            EndWriteAttribute();
            WriteLiteral("rows=\"8\" name=\"describeAuthor\" style=\"width:100%\">");
#nullable restore
#line 66 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
                                                                                                                          Write(name.describeAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
                            </div>
                            <div class=""form-group col-md-6 pt-5 pt-5"">
                                <a href=""../../Admin/AuthorManagement"" name=""submit-cancel"" class=""btn btn-danger"">Hủy</a>
                                <button type=""submit"" name=""submit-save"" class=""btn btn-success"">Lưu</button>
                            </div>
                        </div>
");
#nullable restore
#line 73 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 79 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditAuthor.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">
    function readURL(input){
        if(input.files && input.files[0]){
            var reader = new FileReader();

            reader.onload = function(e){
                $('#show-image').attr('src',e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
    $('#image').change(function(){
        readURL(this);
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<frame.Models.Author> Html { get; private set; }
    }
}
#pragma warning restore 1591
