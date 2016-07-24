<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentAttendanceRecord._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" style="text-align: right" Text="Please select you're user type:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" Width="296px">
                            <asp:ListItem Value="0">Staff</asp:ListItem>
                            <asp:ListItem Value="1">Student</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width: 100%;">
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Username:"></asp:Label>
        </td>
        <td class="auto-style2">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Password:"></asp:Label>
        </td>
        <td class="auto-style2">
            <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6"></td>
        <td class="auto-style11"></td>
        <td class="auto-style8"></td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style10">&nbsp;</td>
        <td class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Log In" Width="100px" Height="26px" OnClick="Button1_Click" />
        </td>
        <td></td>
        <td>&nbsp;</td>
    </tr>
</table>
<p>&nbsp;</p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .auto-style1 {
        width: 138px;
    }
    .auto-style2 {
        width: 288px;
    }
    .auto-style4 {
        width: 293px;
    }
    .auto-style5 {
        width: 270px;
    }
    .auto-style6 {
        width: 293px;
        height: 33px;
    }
    .auto-style8 {
        width: 288px;
        height: 33px;
    }
    .auto-style9 {
        height: 33px;
    }
        .auto-style10 {
            width: 134px;
        }
        .auto-style11 {
            width: 134px;
            height: 33px;
        }
        .auto-style12 {
            width: 264px;
        }
    </style>
</asp:Content>

