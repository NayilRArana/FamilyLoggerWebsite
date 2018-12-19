<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="FamilyLoggerWebsite.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>  
            <br/>

            <span style = "COLOR: green">
                            <asp:Literal runat='server' id='registrationMessage' Text='' />
            </span>
            <table class="auto-style1">  
                <tr>  
                    <td>Email Address</td>  
                    <td>  
                        <asp:TextBox ID="emailBoxLogin" runat="server"></asp:TextBox>
                        <span style = "COLOR: red">
                            <asp:Literal runat='server' id='emailError' Text='' />
                        </span>
                    </td>  
                </tr>  
                <tr>  
                    <td>Password</td>  
                     <td> 
                         <asp:TextBox ID="pwordBoxLogin" runat="server" TextMode="Password"></asp:TextBox>
                         <span style = "COLOR: red">
                            <asp:Literal runat='server' id='pwordError' Text='' />
                        </span>
                     </td>  
                </tr>  
                <tr>  
                    <td>  
                        <asp:Button ID="LoginButton" runat="server" Text="Login" />  
                    </td>  
                </tr>  
                <br />
                <span style = "COLOR: green">
                            <asp:Literal runat='server' id='LoginMessage' Text='' />
                </span>
            </table>  
        </div>
  
</asp:Content>
