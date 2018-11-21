<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>  
            <br/>
            <table class="auto-style1">  
                
                <tr>  
                    <td>First Name</td>  
                    <td>  
                        <asp:TextBox ID="fnameBox" runat="server"></asp:TextBox>  
                        <span style = "COLOR: red">
                            <asp:Literal runat='server' id='fnameError' Text='' />
                        </span>
                    </td>  
  
               </tr>  
                <tr>  
                    <td>Last Name</td>  
                    <td>  
                        <asp:TextBox ID="lnameBox" runat="server"></asp:TextBox>
                        <span style = "COLOR: red">
                            <asp:Literal runat='server' id='lnameError' Text='' />
                        </span>
                    </td>  
  
               </tr> 
                <tr>  
                    <td>Email Address</td>  
                    <td>  
                        <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                        <span style = "COLOR: red">
                            <asp:Literal runat='server' id='emailError' Text='' />
                        </span>
                    </td>  
                </tr>  
                <tr>  
                    <td>Password</td>  
                     <td> 
                         <asp:TextBox ID="pwordBox" runat="server" TextMode="Password"></asp:TextBox>
                         <span style = "COLOR: red">
                            <asp:Literal runat='server' id='pwordError' Text='' />
                        </span>
                     </td>  
                </tr>  
                <tr>  
                    <td>Confirm Password</td>  
                    <td>  
                        <asp:TextBox ID="confirmpwordBox" runat="server" TextMode="Password"></asp:TextBox> 
                        <span style = "COLOR: red">
                            <asp:Literal runat='server' id='confirmpwordError' Text='' />
                        </span>
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                        <asp:Button ID="RegisterButton" runat="server" Text="Register" />  
                    </td>  
                </tr>  
            </table>  
        </div>
  
</asp:Content>
