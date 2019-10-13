<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgotpass.aspx.cs" Inherits="LMS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            margin-left: 320px;
        }
        .auto-style2 {
            font-size: xx-large;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: underline;
        }
        .auto-style3 {
            width: 55%;
            height: 166px;
            margin-right: 0px;
        }
        .auto-style5 {
            height: 362px;
        }
        .auto-style6 {
            width: 203px;
            height: 87px;
        }
        .auto-style7 {
            height: 87px;
        }
        .auto-style8 {
            width: 203px;
            height: 41px;
        }
        .auto-style9 {
            height: 41px;
        }
    </style>
</head>
<body style="height: 79px">
    <form id="form1" runat="server" class="auto-style5">
        <div class="auto-style1">
            <strong>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" ForeColor="Black" Text="Forgot Passsword"></asp:Label>
            </strong>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="None"></asp:TextBox><br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send Email" Width="96px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="verificationLabel" runat="server" Text="Verification Code:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="verificationCode" runat="server" Visible="False"></asp:TextBox>
                    <asp:Button ID="verifyButton" runat="server" OnClick="verifyButton_Click" Text="Verify" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Something went wrong" Visible="false"></asp:Label>

                </td>
                <td>

                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel" />

                </td>
                </tr>
          
           
          
        </table>
    </form>
</body>
</html>
