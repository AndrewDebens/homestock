﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buttons.aspx.cs" Inherits="HomeStock.Testing.Library.Controls.Buttons" %>

<%@ Register Assembly="HomeStockLibrary" Namespace="HomeStockLibrary.Controls" TagPrefix="Control" %>

<asp:content runat="server" id="contentPlaceHolderID" contentplaceholderid="MainViewContent">
    
    <Control:Button runat="server" Text="This is a test" ID="test" Url="http://google.com" OpenTab="true" />

</asp:content>