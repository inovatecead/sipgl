<%@ Page Title="" Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="FrmListaCursosDisponiveis.aspx.cs" Inherits="ufmt.sipgl.View.FrmListaCursosDisponiveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddPreMatriculaPessoaUID" />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <h1>Inscrições Disponíveis</h1>

        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <div style="float: right;">
            <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
        </div>

        <asp:GridView
            ID="GridView1"
            runat="server"
            AllowPaging="True"
            AutoGenerateColumns="False"
            CssClass="mGrid"
            DataKeyNames="preMatriculaPessoaUID"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridViewListaInscricoes_RowDataBound"
            Width="100%">

            <Columns>
                <asp:TemplateField HeaderText="Curso" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbDescricaoCurso" runat="server"><%# Eval("ProjetoCursoUID") %> - <%# Eval("NomeCurso") %></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Turma" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbDescricaoTurma" runat="server"><%# Eval("ProjetoTurmaUID") %> - <%# Eval("DescricaoTurma") %></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data de Início" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}", Eval("DataInicioTurma")) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data Final" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}", Eval("DataFimTurma")) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Situação Atual" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDescricaoSituacaoInscricao" runat="server" Text='<%# Eval("DescricaoSituacaoEnum") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkInscrever" runat="server" Text="Inscrever-se" Font-Bold="true" OnClientClick="return confirm('Deseja realmente se pré-inscrever neste curso?');" CommandName="rojetoTurmaUID" CommandArgument='<%# Eval("ProjetoTurmaUID") %>' OnClick="lnkInscrever_Click"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <asp:Panel ID="Panel1" runat="server">
                    <div style="text-align: left">
                        <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                        <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                        <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" />

                        <asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" ImageUrl="../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />

                        <span class="espacamentoPaginador">Página</span>

                        <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridView1.PageIndex + 1 %>"></asp:Label>

                        <span>de</span>

                        <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridView1.PageCount %>"></asp:Label>
                    </div>
                </asp:Panel>
            </PagerTemplate>
            <EmptyDataTemplate>
                <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
