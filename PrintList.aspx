<%@ Page Title="PrintList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintList.aspx.cs" Inherits="StudentAttendanceRecord.PrintList" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Select Session"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="143px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Select Option:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">Insert presence</asp:ListItem>
                            <asp:ListItem Value="1">Print student list</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style15"></td>
                </tr>
                </table>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="pnl1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style22">
                <asp:Image ID="Image1" runat="server" Height="97px" ImageUrl="I:\StudentAttendanceRecord\StudentAttendanceRecord\Images\greenwichlogo.png" Width="200px" />
            </td>
            <td class="auto-style20">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Label"></asp:Label>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style20">
                &nbsp;</td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Student List:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Select week if different than current:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="StudentSelector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                <asp:Button ID="Button1" runat="server" Text="Enter Attendance" OnClick="Button1_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style21">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Print Student List" />
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Upload From PDA" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 151px;
        }
        .auto-style2 {
            width: 151px;
            height: 44px;
        }
        .auto-style3 {
            height: 44px;
        }
        .auto-style4 {
            width: 604px;
        }
        .auto-style5 {
            height: 44px;
            width: 604px;
        }
        .auto-style6 {
            height: 21px;
        }
        .auto-style11 {
            width: 179px;
            height: 21px;
        }
        .auto-style12 {
            width: 604px;
            height: 21px;
        }
        .auto-style13 {
            width: 179px;
            height: 62px;
        }
        .auto-style14 {
            width: 604px;
            height: 62px;
        }
        .auto-style15 {
            height: 62px;
        }
        .auto-style20 {
            height: 21px;
            width: 402px;
        }
        .auto-style21 {
            width: 402px;
        }
        .auto-style22 {
            width: 267px;
            height: 21px;
        }
        .auto-style23 {
            width: 267px;
        }
        .auto-style24 {
            width: 179px;
            height: 44px;
        }
        .auto-style25 {
            width: 179px;
        }
    </style>
</asp:Content>
