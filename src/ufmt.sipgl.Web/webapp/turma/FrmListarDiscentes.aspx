<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListarDiscentes.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmListarDiscentes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>


    <style type="text/css">
        .modalBackground {
            background-color: black;
            filter: alpha(opacity=90) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }

        .modalPopup {
            padding: 20px 10px 24px 10px;
            position: relative;
            width: 70%;
            background-color: white;
            border: 1px solid black;
            height: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddProjetoCursoUID" />
    <asp:HiddenField runat="server" ID="hddProjetoTurmaUID" />

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <br />

    <asp:TabContainer ID="tabControle" runat="server" AutoPostBack="true" ActiveTabIndex="0">

        <asp:TabPanel ID="tabGeral" runat="server" HeaderText="Geral" Width="100px" TabIndex="0">

            <ContentTemplate>

                <asp:Panel ID="pnlFormularioInscricao" runat="server" Style="padding: 10px">

                    <table class="Largura100Porcento">
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Curso:"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtNomeCurso" runat="server" Width="99.3%" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="lbQuantidadePolos" runat="server" Style="font-weight: 700" Text="Quantidade de Polos:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantidadePolos" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                             <td class="Largura150">
                                <asp:Label ID="lbTotalAlunosMatriculados" runat="server" Style="font-weight: 700" Text="Total de Alunos Matriculados:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAlunosMatriculados" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                             <td class="Largura150">
                                <asp:Label ID="lbTotalPreInscricoes" runat="server" Style="font-weight: 700" Text="Total de Pré-Inscrições:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalPreInscricoes" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="lbQuantidadeVagas" runat="server" Style="font-weight: 700" Text="Quantidade Total de Vagas:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantidadeVagas" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                            <td class="Largura150">
                                <asp:Label ID="lbTotalAlunosAtivos" runat="server" Style="font-weight: 700" Text="Total de Alunos Ativos:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAlunosAtivos" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                            <td class="Largura150">
                                <asp:Label ID="lbTotalPreInscricoesPendentes" runat="server" Style="font-weight: 700" Text="Pré-Inscrições Pendentes:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalPreInscricoesPendentes" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label4" runat="server" Style="font-weight: 700" Text="Data de Início:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDataInicio" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                            <td class="Largura150">
                                <asp:Label ID="lbTotalAlunosInativos" runat="server" Style="font-weight: 700" Text="Total de Alunos Inativos:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAlunosInativos" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                            
                            <td class="Largura150">
                                <asp:Label ID="lbTotalPreInscricoesAprovadas" runat="server" Style="font-weight: 700" Text="Pré-Inscrições Aprovadas:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalPreInscricoesAprovadas" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label5" runat="server" Style="font-weight: 700" Text="Data de Final:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDataFinal" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                            <td class="Largura150">
                                <asp:Label ID="lbTotalAlunosFormados" runat="server" Style="font-weight: 700" Text="Total de Alunos Formados:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAlunosFormados" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>

                            <td class="Largura150">
                                <asp:Label ID="lbTotalPreInscricoesCanceladas" runat="server" Style="font-weight: 700" Text="Pré-Inscrições Canceladas:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalPreInscricoesCanceladas" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                    </table>

                    <br />

                    <asp:GridView
                        ID="GridViewPolos"
                        runat="server"
                        Width="100%"
                        CssClass="mGrid"
                        Enabled="true"
                        Visible="true"
                        AutoGenerateColumns="false"
                        ShowHeaderWhenEmpty="true">

                        <Columns>
                            <asp:TemplateField HeaderText="Polo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbPolo" runat="server" Text='<%# Eval("IdentificacaoEndereco") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total de Vagas" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotalVagas" runat="server" Text='<%# Eval("TotalVagasPolo") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total de Alunos Matriculados" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotalAlunosMatriculados" runat="server" Text='<%# Eval("TotalAlunosMatriculados") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total de Alunos Ativos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotalAlunosAtivos" runat="server" Text='<%# Eval("TotalAlunosAtivos") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total de Alunos Inativos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotalAlunosInativos" runat="server" Text='<%# Eval("TotalAlunosInativos") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total de Alunos Formados" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbTotalAlunosFormados" runat="server" Text='<%# Eval("TotalAlunosFormados") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                                <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta." Visible="true"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>

                </asp:Panel>

            </ContentTemplate>

        </asp:TabPanel>

        <asp:TabPanel ID="tabAlunos" runat="server" HeaderText="Alunos" TabIndex="1">

            <ContentTemplate>

                <fieldset style="padding: 10px">
                    <legend>
                        <img alt="Filtrar Registros" class="style2" src="../../media/images/ico_filters.png" />
                        <span>Filtrar Registros</span>
                    </legend>

                    <asp:Panel ID="PanelFiltro" runat="server">
                        <table class="Largura100Porcento">
                            <tr>
                                <td class="LarguraFiltro">
                                    <asp:Label ID="lbPolo" runat="server">Polo:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPolo" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="LarguraFiltro">
                                    <asp:Label ID="lbTipoSituacaoInscricao" runat="server">Situação:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoSituacaoInscricao" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="LarguraFiltro"></td>

                                <td>
                                    <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                                        <span>Consultar</span>
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                </fieldset>

                <asp:Panel ID="PanelAcoes" runat="server">

                    <div class="addbutton" style="float: left; margin-right: 5px">
                        <asp:HyperLink ID="lnkIncluirDiscente" runat="server" CssClass="minibutton" SkinID="Discentes_IncluirDiscente">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Incluir Discente
                            </span>
                        </asp:HyperLink>
                    </div>

                    <div class="addbutton" style="float: left; margin-right: 5px">
                        <asp:HyperLink ID="lnkIncluirLote" runat="server" CssClass="minibutton" SkinID="Discentes_IncluirLote">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Incluir em Lote
                            </span>
                        </asp:HyperLink>
                    </div>

                    <div class="addbutton" style="float: left; margin-right: 5px">
                        <asp:HyperLink ID="lnkGerenciarPreInscricao" runat="server" CssClass="minibutton" SkinID="Discentes_GerenciarPreInscricao">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Gerenciar Pré-Inscrições
                            </span>
                        </asp:HyperLink>
                    </div>

                    <asp:Button runat="server" ID="gerarRelatorioPDF" OnClick="gerarRelatorioPDF_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Gerar Relatório (.pdf)" SkinID="Discentes_RelatorioPDF" />
                    <asp:Button runat="server" ID="gerarRelatorioExcel" OnClick="gerarRelatorioExcel_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Gerar Relatório (.xls)" SkinID="Discentes_RelatorioXLS" />

                    <div style="float: right;">
                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
                    </div>
                </asp:Panel>

                <asp:GridView
                    ID="GridViewListaDiscentes"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    OnPageIndexChanging="GridViewListaDiscentes_PageIndexChanging"
                    Width="100%"
                    CssClass="mGrid"
                    DataKeyNames="preMatriculaInscricaoUID"
                    PageSize="10"
                    OnRowCommand="abrirModal_Click"
                    ShowHeaderWhenEmpty="true"
                    OnRowDataBound="GridViewListaDiscentes_RowDataBound">

                    <Columns>
                        <asp:TemplateField HeaderText="Polo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("identificacaoEndereco")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RGA" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("RGA")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("nome")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("CPF")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("email")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Situação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("tipoSituacaoInscricao")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                <asp:ImageButton runat="server" ID="lnkVisualizarHistorico" SkinID="Discentes_VisualizarHistorico" ImageUrl="~/media/images/view_20.png" CommandArgument='<%# Eval("preMatriculaInscricaoUID") %>' CommandName="preMatriculaInscricaoUID" ToolTip="Visualizar Histórico" />

                                <asp:HyperLink ID="lnkEditarSituacaoAluno" runat="server" SkinID="Discentes_EditarSituacao" NavigateUrl='<%# "~/webapp/turma/FrmAlteracaoSituacao.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&preMatriculaInscricaoUID=" + Eval("preMatriculaInscricaoUID") +"&ddlPolo=" + ddlPolo.SelectedValue +"&ddlTipoSituacaoInscricao=" + ddlTipoSituacaoInscricao.SelectedValue + "&page=" + GridViewListaDiscentes.PageIndex %>' ToolTip="Editar Situação do Aluno">
                                        <asp:Image runat="server" ImageUrl="~/media/images/tools_20.png" />
                                </asp:HyperLink>

                                <asp:LinkButton ID="lnkExcluirRegistroDiscente" runat="server" SkinID="Discentes_ExcluirDiscente" ToolTip="Excluir Discente" OnClientClick="return confirm('Todas as notas, registro de frequência e ocorrências associadas serão excluídas permanentemente. Deseja realmente excluir este registro? ');" CommandName="lnkExcluir_Click" OnCommand="lnkExcluir_Click" CommandArgument='<%# Eval("preMatriculaInscricaoUID") + ";" + GridViewListaDiscentes.PageIndex %>' Visible="false">
                                        <asp:Image runat="server" ImageUrl="~/media/images/trash_16.gif" />
                                </asp:LinkButton>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>

                    </Columns>


                    <PagerTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <div style="text-align: left">
                                <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                                <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                                <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" CssClass="espacamentoPaginador" />

                                <asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />

                                <span class="espacamentoPaginador">Página</span>

                                <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridViewListaDiscentes.PageIndex + 1 %>"></asp:Label>

                                <span>de</span>

                                <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridViewListaDiscentes.PageCount %>"></asp:Label>
                            </div>
                        </asp:Panel>
                    </PagerTemplate>

                    <EmptyDataTemplate>
                        <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                            <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                        </div>
                    </EmptyDataTemplate>

                </asp:GridView>

                <asp:Button runat="server" ID="btnDummy" Text="Botão Dummy" Style="display: none" />

                <asp:ModalPopupExtender
                    runat="server"
                    ID="modalHistorico"
                    TargetControlID="btnDummy"
                    PopupControlID="modalPanel"
                    CancelControlID="fecharModal"
                    BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>

                <asp:Panel runat="server" ID="modalPanel" CssClass="modalPopup">

                    <h1>
                        <asp:Label ID="lbTituloHistoricoAlteracoes" runat="server">Histórico de Alterações</asp:Label>
                    </h1>

                    <br />

                    <div style="height: auto; max-height: 220px; overflow: auto;">

                        <asp:GridView
                            ID="GridViewHistoricoSituacao"
                            runat="server"
                            Width="100%"
                            CssClass="mGrid"
                            Enabled="true"
                            Visible="true"
                            AutoGenerateColumns="false"
                            ShowHeaderWhenEmpty="true">

                            <Columns>
                                <asp:TemplateField HeaderText="Data" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPolo" runat="server" Text='<%# Eval("dataHoraOcorrencia", "{0:dd/MM/yyyy HH:mm:ss}") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Situação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTotalVagas" runat="server" Text='<%# Eval("tipoSituacaoInscricao") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Usuário" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTotalAlunosMatriculados" runat="server" Text='<%# Eval("usuario") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Observação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTotalAlunosAtivos" runat="server" Text='<%# Eval("observacao") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="55%" />
                                </asp:TemplateField>
                            </Columns>

                            <EmptyDataTemplate>
                                <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta." Visible="true"></asp:Label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>

                    <div style="padding: 10px; text-align: center">
                        <asp:Button runat="server" ID="fecharModal" Text="Fechar" />
                    </div>
                </asp:Panel>

            </ContentTemplate>

        </asp:TabPanel>

    </asp:TabContainer>



</asp:Content>
