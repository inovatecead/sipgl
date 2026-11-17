<%@ Page Title="" Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="FrmListaInscricao.aspx.cs" Inherits="ufmt.sipgl.View.FrmListaInscricao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function showDialog(id) {
            $('.' + id).dialog("open");
        }

        function closeDialog(id) {
            $('.' + id).dialog("close");
        }
    </script>


    <style type="text/css">
        .detalhes {
            text-align: justify;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddPreMatriculaPessoaUID" />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <h1>Inscrições Realizadas</h1>

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
            DataKeyNames="preMatriculaInscricaoUID"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            Width="100%">

            <Columns>
                <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("projetoCursoUID") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Curso" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href="javascript:void(0);" class="mestre"><%# Eval("cursoNome") %></a>
                        <div class="detalhes" style="display: none; background-color: #EBEBEB; color: Black; margin-top: 5px">
                            <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Polo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("municipio") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Turma" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("descricaoTurma") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data Início" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}", Eval("projetoTurmaDataInicio")) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data Fim" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}", Eval("projetoTurmaDataFim")) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Situação Atual" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDescricaoSituacaoInscricao" runat="server" Text='<%# Eval("tipoSituacaoInscricaoNome") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkNotas" runat="server" Text="Notas" CommandName="preMatriculaInscricaoUID" CommandArgument='<%# Eval("preMatriculaInscricaoUID") %>' OnClick="lnkExibirNotas_Click" OnClientClick="window.document.forms[0].target='_blank';"></asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="lnkHistorico" runat="server" Text="Histórico Escolar" CommandName="preMatriculaInscricaoUID" CommandArgument='<%# Eval("preMatriculaInscricaoUID") %>' OnClick="lnkHistorico_Click" OnClientClick="window.document.forms[0].target='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="cmdIr">
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
