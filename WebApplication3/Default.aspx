<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                <h2 runat="server" id="fecha">https://pos.dermalia.mx/webforms/data</h2>
            </section>

            <div runat="server" id="divTable">

                <asp:UpdatePanel runat="server" ID="UpdatePanel">
                    <ContentTemplate>
                        <asp:Table ID="Table1" runat="server"
                            Style="border-width: 1px; border-style: Solid; width: 100%;">
                            <asp:TableRow>
                                <asp:TableCell>Primer Apellido</asp:TableCell>
                                <asp:TableCell>Segundo Apellido</asp:TableCell>
                                <asp:TableCell>Nombre</asp:TableCell>
                                <asp:TableCell>Sexo</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <h4 runat="server" id="registroModificado"></h4>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </main>

</asp:Content>
