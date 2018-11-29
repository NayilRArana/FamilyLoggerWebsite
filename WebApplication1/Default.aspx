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
        <div class="col-md-4">
            <h2>Monitor keystrokes</h2>
            <p>
                Once installed onto your child's PC, our application monitors all keys pressed!
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>View reports online</h2>
            <p>
                Our website makes it easy to view the keystroke reports wherever you are!
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        
    </div>

</asp:Content>
