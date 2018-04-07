<%@ Page Title="홈 페이지" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ObjectDataSourceSample._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxNewsControl" tagprefix="dx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    Paging 처리<br />
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="ods" KeyFieldName="Seq"
        DataSourceForceStandardPaging="True" AutoGenerateColumns="False">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                <EditButton Visible="True">
                </EditButton>
                <NewButton Visible="True">
                </NewButton>
                <DeleteButton Visible="True">
                </DeleteButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Seq" ReadOnly="true">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="Emp_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Emp_nm">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="Phone_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="Sex">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="6" FieldName="Remarks">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ods" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords" DataObjectTypeName="Domain.CHrinfo"
                SelectCountMethod="GetListCount" SelectMethod="getHrinfoList" TypeName="BLL.HrinfoImpl" InsertMethod="SetHrinfoList" DeleteMethod="DelHrinfoList" UpdateMethod="UpHrinfoList">
    </asp:ObjectDataSource>
    <br />
    <br />
</asp:Content>
