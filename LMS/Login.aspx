<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 212px;
        }
        .auto-style2 {
            width: 90px;
        }
        .auto-style3 {
            width: 90px;
            height: 26px;
        }
        .auto-style4 {
            width: 212px;
            height: 26px;
        }
    </style>
    
</head>
<body style="background-image:url('Images/Tree.jpg')">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table style="margin:auto; border:5px solid white ">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbluser" runat="server" Text="Username: "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
                    </td>
                </tr>


                 <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblpass" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td class="auto-style2">
                        
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="Login" Width="66px" OnClick="Button1_Click" />
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style3">
                        
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblerror" runat="server" Text="Sorry! Invalid Credentials..." ForeColor="Red"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
  
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Forgotpass.aspx">Reset Password</asp:HyperLink>
                    </td>
                  
                </tr>






            </table>
        </div>
    </form>
</body>
</html>
