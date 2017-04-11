﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Button.aspx.cs" Inherits="HomeStock.Testing.Library.Controls.Buttons" %>

<%@ Register Assembly="HomeStockLibrary" Namespace="HomeStockLibrary.Controls" TagPrefix="Control" %>

<asp:content runat="server" id="contentPlaceHolderID" contentplaceholderid="MainViewContent">
    
    <Control:PageHeader runat="server" Title="Button" Description="Below is a various set of different possible button configurations" />

    <Control:Button runat="server" Text="Default" ID="Button3" Type="Default"/>
    <Control:Button runat="server" Text="New" ID="Button4" Type="New" />
    <Control:Button runat="server" Text="Delete" ID="Button5"  Type="Delete" />

    <Control:PageSerpoator runat="server" Text="External Navigation" />

    <Control:Button runat="server" Text="Google" ID="test" Url="http://google.com" />
    <Control:Button runat="server" Text="Google In New Tab" ID="Button1" Url="http://google.com" OpenTab="true" />

</asp:content>