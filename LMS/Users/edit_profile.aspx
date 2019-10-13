<%@ Page Title="" Language="C#" MasterPageFile="~/Users/user.Master" AutoEventWireup="true" CodeBehind="edit_profile.aspx.cs" Inherits="LMS.Users.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="UserDetailsView" runat="server" Height="50px" Width="511px" AutoGenerateRows="False" DataKeyNames="empID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnModeChanging ="UserDetailsView_ModeChanging" OnItemUpdating="UserDetailsView_ItemUpdating" OnPageIndexChanging="UserDetailsView_PageIndexChanging"  >
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="empID" HeaderText="empID" SortExpression="empID" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="JoiningDate" HeaderText="JoiningDate" SortExpression="JoiningDate" />
            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="TotalLeaves" HeaderText="TotalLeaves" SortExpression="TotalLeaves" />
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            <asp:BoundField DataField="usertype" HeaderText="usertype" SortExpression="usertype" />
            <asp:BoundField DataField="LeavesTaken" HeaderText="LeavesTaken" SortExpression="LeavesTaken" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LMSConnectionString %>" SelectCommand="emp_Detail" UpdateCommand="UPDATE empDetails SET Mobile = @Mobile, Email = @Email, Address = @Address WHERE (empID = @empID)" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="empID" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Mobile" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="empID" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    </asp:Content>
