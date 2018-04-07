<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Test0509.Views.test" %>

<%@ Register Assembly="DevExpress.Xpo.v14.1.Web, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton" 
            onclick="ASPxButton1_Click">
        </dx:ASPxButton>
    </div>
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="Seq" AutoGenerateColumns="false"
            DataSourceID="XpoDataSource1" Width="100%" OnBatchUpdate="ASPxGridView1_BatchUpdate">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowSelectCheckbox="true" Width="40px"
                    FixedStyle="Left" ButtonType="Image">
                    <HeaderTemplate>
                        <input type="checkbox" onclick="grid.SelectAllRowsOnPage(this.checked);" />
                    </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="고유번호" FieldName="Seq" Width="100px" Visible="false"
                    VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="사원이름" FieldName="Print_emp_nm" Width="100px"
                    VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="사원이름(영문)" FieldName="Print_emp_enm" VisibleIndex="3"
                    Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="회사명" FieldName="Print_comp_nm" Width="100px"
                    Visible="true">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="부서명" FieldName="Print_dept_nm" Width="100px"
                    Visible="true">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="직급명" FieldName="Print_posi_nm" Width="100px"
                    Visible="true">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsEditing Mode="Batch" EditFormColumnCount="30" />
        </dx:ASPxGridView>
    </div>
    <dx:XpoDataSource ID="XpoDataSource1" runat="server" ServerMode="true" TypeName="Test0509.Xpo.CardApprovalEntity">
    </dx:XpoDataSource>
    </form>
</body>
</html>
