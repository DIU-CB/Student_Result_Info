#pragma checksum "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "877fdf790c76bf643d04a3369a537534c29e6a7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditEducation), @"mvc.1.0.view", @"/Views/Home/EditEducation.cshtml")]
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
#line 1 "E:\StudentEducationInfo\StudentEducationInfo\Views\_ViewImports.cshtml"
using StudentEducationInfo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\StudentEducationInfo\StudentEducationInfo\Views\_ViewImports.cshtml"
using StudentEducationInfo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"877fdf790c76bf643d04a3369a537534c29e6a7c", @"/Views/Home/EditEducation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea45e40e17baba9320bc3a0a3ebdab815166b05d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditEducation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentEducationInfo.Models.StudentEducationModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditEducations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"form-group col-md-5\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "877fdf790c76bf643d04a3369a537534c29e6a7c4236", async() => {
                WriteLiteral("\r\n        <h1>Edit Education Record </h1><br />\r\n        <label>Student ID:</label>\r\n        <input class=\"form-control\" readonly=\"readonly\" type=\"text\" name=\"StudentID\"");
                BeginWriteAttribute("value", " value=\"", 338, "\"", 362, 1);
#nullable restore
#line 7 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 346, Model.StudentID, 346, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required />\r\n        <input type=\"hidden\" name=\"PersonID\"");
                BeginWriteAttribute("value", " value=\"", 421, "\"", 444, 1);
#nullable restore
#line 8 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 429, Model.PersonID, 429, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("  />\r\n        <label>Degree:</label>\r\n");
                WriteLiteral("        <input class=\"form-control\" readonly=\"readonly\" type=\"text\" name=\"Degree\"");
                BeginWriteAttribute("value", " value=\"", 907, "\"", 928, 1);
#nullable restore
#line 17 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 915, Model.Degree, 915, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required /><br />\r\n        <label>Major Subject</label>\r\n        <input class=\"form-control\" type=\"text\" readonly=\"readonly\" name=\"MajorSubject\"");
                BeginWriteAttribute("value", " value=\"", 1074, "\"", 1101, 1);
#nullable restore
#line 19 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 1082, Model.MajorSubject, 1082, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required /><br />\r\n        <label>Institute</label>\r\n        <input class=\"form-control\" type=\"text\" name=\"Institute\"");
                BeginWriteAttribute("value", " value=\"", 1220, "\"", 1244, 1);
#nullable restore
#line 21 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 1228, Model.Institute, 1228, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required /><br />\r\n        <label>University/Board</label>\r\n        <input class=\"form-control\" type=\"text\" name=\"Board\"");
                BeginWriteAttribute("value", " value=\"", 1366, "\"", 1386, 1);
#nullable restore
#line 23 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 1374, Model.Board, 1374, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required /><br />\r\n\r\n        <label>Passing Year:</label><br />\r\n\r\n        <input type=\"number\" class=\"datepicker\" name=\"PassingYear\"");
                BeginWriteAttribute("value", " value=\"", 1521, "\"", 1547, 1);
#nullable restore
#line 27 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 1529, Model.PassingYear, 1529, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required /><br />\r\n        <label>CGPA</label>\r\n        <input class=\"form-control\" type=\"number\" min=\"0\" name=\"CGPA\"");
                BeginWriteAttribute("value", " value=\"", 1666, "\"", 1685, 1);
#nullable restore
#line 29 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
WriteAttributeValue("", 1674, Model.CGPA, 1674, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" step=\".01\" placeholder=\"Upto 2 Decimal digit\" required /><br />\r\n\r\n        <button type=\"submit\" class=\"btn btn-info\">Update Record</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js""></script>
    <script type=""text/javascript"">
        $(document).ready( function () {

            $("".datepicker"").datepicker({
                format: 'yyyy', autoclose: true, viewMode: ""years"",
                minViewMode: ""years""
            })

        } );
    $(function () {
        var save = '");
#nullable restore
#line 47 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
               Write(TempData["save"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n        if (save != \'\') {\r\n            alertify.success(save);\r\n        }\r\n        var edit = \'");
#nullable restore
#line 51 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
               Write(TempData["edit"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n        var noData=\'");
#nullable restore
#line 52 "E:\StudentEducationInfo\StudentEducationInfo\Views\Home\EditEducation.cshtml"
               Write(TempData["noData"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n        if (edit != \'\') {\r\n            alertify.warning(edit);\r\n        }\r\n        if (noData != \'\') {\r\n            alertify.error(noData);\r\n        }\r\n    })\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentEducationInfo.Models.StudentEducationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
