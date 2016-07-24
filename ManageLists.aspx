<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageLists.aspx.cs" Inherits="StudentAttendanceRecord.About" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <table style="width: 100%; margin-bottom: 39px;">
                <tr>
            <td class="auto-style93">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Please select Course to see student List:"></asp:Label>
                    </td>
            <td class="auto-style64">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="207px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style52">
            </td>
            <td class="auto-style53">
            </td>
            <td class="auto-style54">
            </td>
            <td class="auto-style54"></td>
                &nbsp;</td>
            </table>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width:100%;">
        <tr>
            <td class="auto-style79">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Course Manager Options:"></asp:Label>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style80">
                <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="Select Session:"></asp:Label>
            </td>
            <td class="auto-style47">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">Lecture</asp:ListItem>
                    <asp:ListItem Value="1">Laboratory</asp:ListItem>
                    <asp:ListItem Value="2">Tutorial</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style24"></td>
        </tr>
        <tr>
            <td class="auto-style81">
                <asp:Label ID="Label15" runat="server" Font-Size="Large" Text="Available Rooms:"></asp:Label>
            </td>
            <td class="auto-style48">
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" Width="61px">
                </asp:CheckBoxList>
            </td>
            <td class="auto-style95"></td>
                &nbsp;</td>
            <td class="auto-style46"></td>
            <td></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style83">
                <asp:Label ID="Label17" runat="server" Font-Size="Large" Text="Available time slots:"></asp:Label>
            </td>
            <td class="auto-style84">
                <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" Width="166px">
                    <asp:ListItem>Monday</asp:ListItem>
                    <asp:ListItem>Tuesday</asp:ListItem>
                    <asp:ListItem>Wednesday</asp:ListItem>
                    <asp:ListItem>Thursday</asp:ListItem>
                    <asp:ListItem>Friday</asp:ListItem>
                    <asp:ListItem>Saturday</asp:ListItem>
                    <asp:ListItem>Sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style96">
                <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="166px" AutoPostBack="True">
                    <asp:ListItem>09:00 - 11:00</asp:ListItem>
                    <asp:ListItem>11:00 - 13:00</asp:ListItem>
                    <asp:ListItem>13:00 - 15:00</asp:ListItem>
                    <asp:ListItem>15:00 - 17:00</asp:ListItem>
                    <asp:ListItem>17:00 - 19:00</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style86"></td>
            <td class="auto-style87"></td>
            <td class="auto-style85"></td>
        </tr>
        <tr>
            <td class="auto-style81">
                <asp:Label ID="Label16" runat="server" Font-Size="Large" Text="Available Teachers:"></asp:Label>
            </td>
            <td class="auto-style48">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="166px">
                </asp:DropDownList>
            </td>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style81">&nbsp;</td>
            <td class="auto-style48">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
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
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84"></td>
            <td class="auto-style96"></td>
            <td class="auto-style86"></td>
            <td class="auto-style87"></td>
            <td class="auto-style85"></td>
        </tr>
        <tr>
            <td class="auto-style81">&nbsp;</td>
            <td class="auto-style48">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Students" />
            </td>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style81">&nbsp;</td>
            <td class="auto-style48">&nbsp;</td>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84"></td>
            <td class="auto-style96"></td>
            <td class="auto-style86"></td>
            <td class="auto-style87"></td>
            <td class="auto-style85"></td>
        </tr>
        <tr>
            <td class="auto-style88">
                &nbsp;</td>
            <td class="auto-style89">
                &nbsp;</td>
            <td class="auto-style97">
                &nbsp;</td>
            <td class="auto-style91">&nbsp;</td>
            <td class="auto-style92"></td>
            <td class="auto-style90"></td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84"></td>
            <td class="auto-style96"></td>
            <td class="auto-style86"></td>
            <td class="auto-style87"></td>
            <td class="auto-style85"></td>
        </tr>
        <tr>
            <td class="auto-style81">&nbsp;</td>
            <td class="auto-style48">&nbsp;</td>
            <td class="auto-style95">&nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style81">
                &nbsp;</td>
            <td class="auto-style48">
                &nbsp;</td>
            <td class="auto-style95">
                &nbsp;</td>
            <td class="auto-style46">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style4 {
            height: 23px;
            width: 156px;
        }
        .auto-style6 {
            height: 23px;
            width: 270px;
        }
        .auto-style7 {
            width: 456px;
        }
        .auto-style24 {
            height: 24px;
            width: 270px;
        }
        .auto-style46 {
            width: 264px;
        }
        .auto-style47 {
            height: 24px;
            width: 156px;
        }
        .auto-style48 {
            width: 156px;
        }
        .auto-style52 {
            width: 58px;
            height: 29px;
        }
        .auto-style53 {
            width: 37px;
            height: 29px;
        }
        .auto-style54 {
            width: 84px;
            height: 29px;
        }
        .auto-style64 {
            width: 110px;
            height: 29px;
        }
        .auto-style79 {
            height: 23px;
            width: 467px;
        }
        .auto-style80 {
            height: 24px;
            width: 467px;
        }
        .auto-style81 {
            width: 467px;
        }
        .auto-style83 {
            width: 467px;
            height: 21px;
        }
        .auto-style84 {
            width: 156px;
            height: 21px;
        }
        .auto-style85 {
            width: 456px;
            height: 21px;
        }
        .auto-style86 {
            width: 264px;
            height: 21px;
        }
        .auto-style87 {
            height: 21px;
        }
        .auto-style88 {
            width: 467px;
            height: 29px;
        }
        .auto-style89 {
            width: 156px;
            height: 29px;
        }
        .auto-style90 {
            width: 456px;
            height: 29px;
        }
        .auto-style91 {
            width: 264px;
            height: 29px;
        }
        .auto-style92 {
            height: 29px;
        }
        .auto-style93 {
            width: 239px;
            height: 29px;
        }
        .auto-style95 {
            width: 270px;
        }
        .auto-style96 {
            width: 270px;
            height: 21px;
        }
        .auto-style97 {
            width: 270px;
            height: 29px;
        }
    </style>
</asp:Content>
