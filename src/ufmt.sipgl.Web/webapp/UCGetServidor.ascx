<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGetServidor.ascx.cs" Inherits="ufmt.sipgl.View.webapp.UCGetServidor" %>
<style>
 .containerFormulario { margin-bottom:10px; margin-top:10px; padding-left:10px; } .center { text-align:center }
</style>
<asp:UpdatePanel ID="updPnlListaServidores" runat="server">
    <ContentTemplate>
    <div id="containerMensagens">
                <asp:Panel ID="PanelMsgResultadoUC" runat="server" Visible="false">
                    <asp:Label ID="lblMsgResultadoUC" runat="server"></asp:Label>
                </asp:Panel>
    </div>
    <div class="containerFormulario">
    
        <asp:Panel ID="pnlCoordenadorAtual" runat="server" Visible="true">
            <fieldset>
            <legend>Coordenador / Responsável atual</legend>
            <p>
                Nome: <asp:Label ID="lblnomeatual" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                CPF: <asp:Label ID="lblcpfatual" runat="server" Text="Label"></asp:Label>        
            </p>
            <p>
                Matrícula: <asp:Label ID="lblmatriculaatual" runat="server" Text="Label"></asp:Label>        
                <asp:HiddenField ID="hdrespatual" runat="server" />
            </p>
            </fieldset>
        </asp:Panel>
    </div>

    <div class="containerFormulario">
        <asp:Panel ID="pnlInfoServidor" runat="server" Visible="false">
        <fieldset>
            <legend>Responsável Selecionado:</legend>
        
        <p>
            Nome: <asp:Label ID="lblnome" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            CPF: <asp:Label ID="lblcpf" runat="server" Text="Label"></asp:Label>        
        </p>
        <p>
            Matrícula: <asp:Label ID="lblmatricula" runat="server" Text="Label"></asp:Label>        
            <asp:HiddenField ID="hdrespnovo" runat="server" />
        </p>
        <p class="center">
            <asp:Button ID="btConfirmar" runat="server" Text="Confirmar Alteração" 
                onclick="btConfirmar_Click" />
        </p>
        </fieldset>
        </asp:Panel>

    <asp:Panel ID="pnlCoordenador" runat="server">

    <div id="divConsultaServidor" runat="server">
    <fieldset>
         <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updPnlListaServidores">
        <ProgressTemplate>
        <div style="text-align:left">
            &nbsp;<asp:Image ID="Image8" runat="server" 
                ImageUrl="~/images/loading_circle.gif" />
            &nbsp;Processando...
        </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
        
        <asp:Label ID="lblBuscaCoordenador" runat="server" 
            Text="Localizar Responsável/Coordenador" style="font-weight: 700"></asp:Label>       
        <br />
        <asp:TextBox ID="txtBuscaCoordenador" runat="server" Width="400px"></asp:TextBox>
        &nbsp;<asp:DropDownList ID="ddlBuscaCoordenador" runat="server">
            <asp:ListItem>Nome</asp:ListItem>
            <asp:ListItem>CPF</asp:ListItem>
            <asp:ListItem Value="siape">Registro SIAPE</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/media/images/busca.png" CssClass="imgBtBuscar" 
            onclick="ImageButton1_Click" />
<asp:Panel ID="pnlListaServidores" runat="server" Visible="False">
        Selecione o coordenador.
            <asp:GridView ID="gdrListaServidores" runat="server" 
                AutoGenerateColumns="False"
                AllowPaging="True" Width="100%"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" DataKeyNames="ServidorUID" 
                onselectedindexchanged="gdrListaServidores_SelectedIndexChanged"
                >            
                <AlternatingRowStyle CssClass="alt" />
                <Columns>                    
                    <asp:TemplateField HeaderText="Selecionar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="minibutton" ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="select">
                            <span>
                                <img src="../../media/images/select.png" alt="" />
                                Selecionar
                            </span>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Registro" HeaderText="Registro SIAPE" ItemStyle-HorizontalAlign="Center" 
                        SortExpression="Registro" ItemStyle-Width="120px">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        Nome do Servidor
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='  <%# Eval("Pessoa.Nome")%>'></asp:Label>
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pgr" />
            </asp:GridView>
            
           
            
        </asp:Panel>

</fieldset>
    </div>
    
    </asp:Panel>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>