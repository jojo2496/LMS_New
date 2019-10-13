<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeForm.aspx.cs" Inherits="LMS.Admin.AddEmployeeForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
</head>
<body>
    <form id="form1" runat="server" onload="Page_Load">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblusertype" runat="server" Text="User Type: "></asp:Label>
                </td>
                <td>
                    <ajaxToolkit:ComboBox ID="ComboBox1" runat="server" DropDownStyle="DropDownList" AutoPostBack="True">
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem Selected="True">Employee</asp:ListItem>
                    </ajaxToolkit:ComboBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="lblname" runat="server" Text="Name:"></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblgender" runat="server" Text="Gender: "></asp:Label>&nbsp;&nbsp;
                    </td>
                 <td>
                    <asp:DropDownList ID="genderlist" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbljdate" runat="server" Text="Joining Date: "></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtjdate" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmobile" runat="server" Text="Mobile No:"></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtmobile" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmail" runat="server" Text="Email:"></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbladd" runat="server" Text="Address: "></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtadd" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbldob" runat="server" Text="Date Of Birth: "></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txtdob" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbltleaves" runat="server" Text="Total Leaves: "></asp:Label>&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:TextBox ID="txttleaves" runat="server" TextMode="Number" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbluname" runat="server" Text=" Set Username:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtuname" runat="server" AutoCompleteType="None"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="lblpass" runat="server" Text="Set Password: " ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpass" runat="server" AutoCompleteType="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                         <asp:Button ID="Button2" runat="server" Text="Save"  OnClick="Button2_Click"/>

                </td>
                <td>
                         <asp:Button ID="Button4" runat="server" Text="Cancel" OnClick="Button4_Click" />
              
                </td>
                
                     <td>
                         &nbsp;</td>
            </tr>
       

        </table>
        
    </form>
</body>
</html>
