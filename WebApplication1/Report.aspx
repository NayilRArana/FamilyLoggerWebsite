<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="FamilyLoggerWebsite.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Report</h2>
        <div class="well" ID="reportText"><%=report%></div>
        </div>
</asp:Content>
