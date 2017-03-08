<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testArchivos.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .oculto{
            display:none;
        }
    </style>

    <script src="Scripts/jquery-3.1.1.js"></script>
    <script>
        $(document).ready(function () {

            $(".btnLimpiar").click(function () {

             
                 $(this).prev().prev("input[type='file']").val('');
               
                
            });
            $(".btnCambiar").click(function () {
                $(this).prev("a").addClass("oculto");
                $(this).next("input[type='file']").removeClass("oculto");
                $(this).next().next().next("input[type='button']").removeClass("oculto");
                
                $(this).addClass("oculto");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="ir" />
</asp:Content>
