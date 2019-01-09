<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>FamilyLogger</h1>
        <p class="lead">FamilyLogger is a free parental supervision application for logging activity on your child's PC.</p>
        <div class = "row">
            <div class="col-md-2">
                <p><a href="/Login" class="btn btn-primary btn-lg">Login &raquo;</a></p>
            </div>
            <div class = "col-md-2">
                <p><a href="/Registration" class="btn btn-primary btn-lg">Register &raquo;</a></p>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Monitor keystrokes</h2>
            <p>
                Once installed onto your child's PC, our application monitors all keys pressed!
            </p>
        </div>
        <div class="col-md-6">
            <h2>For educational purposes only</h2>
            <p>
                Once installed and run, the application remains visible at all times and does not send out any information.
            </p>
        </div>
    </div>

</asp:Content>
