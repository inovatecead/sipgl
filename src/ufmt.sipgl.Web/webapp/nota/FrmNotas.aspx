<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmNotas.aspx.cs" Inherits="ufmt.sipgl.View.webapp.nota.FrmNotas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />
    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <fieldset style="padding: 10px">
        <legend>Curso</legend>

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbCurso" runat="server" Style="font-weight: 700" Text="Curso:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCurso" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbTurma" runat="server" Style="font-weight: 700" Text="Turma:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTurma" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro">
                    <asp:Label runat="server" ID="Label1">Polo:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPolo" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPolo" ErrorMessage="Polo" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro">
                    <asp:Label runat="server" ID="Label2">Disciplina:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDisciplina" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDisciplina" ErrorMessage="Disciplina" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro"></td>
                <td>
                    <asp:LinkButton ID="lnkFiltrar" runat="server" CssClass="minibutton" OnClick="lnkFiltrar_Click">
                                    <asp:Label runat="server">Filtrar</asp:Label>
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
    </fieldset>

    <asp:Panel ID="panelDiscentes" runat="server">
        <fieldset style="padding: 10px">
            <legend>Discentes</legend>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDocentePrincipal" runat="server" Style="font-weight: 700" Text="Docente Principal:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocentePrincipal" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDocenteSecundario" runat="server" Style="font-weight: 700" Text="Docente Secundário:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocenteSecundario" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />

            <asp:Button runat="server" ID="gerarRelatorioPDF" OnClick="gerarRelatorioPDF_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Gerar Relatório (.pdf)" SkinID="Nota_GerarRelatorioPDF" />
            <asp:Button runat="server" ID="btnOpenPopUp" Text="Importar Notas" OnClick="btnOpenPopUp_Click" Visible="false" SkinID="Nota_ImportarLote"/>

            <asp:GridView
                ID="GridViewNotas"
                runat="server"
                AllowPaging="false"
                AutoGenerateColumns="false"
                Width="100%"
                CssClass="mGrid"
                OnRowDataBound="GridViewNotas_RowDataBound"
                DataKeyNames="preMatriculaInscricaoUID"
                ShowHeaderWhenEmpty="true">

                <Columns>
                    <asp:TemplateField HeaderText="Discente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hddPreMatriculaInscricaoUID" runat="server" Value='<%# Eval("PreMatriculaInscricaoUID") %>' />

                            <asp:Label ID="lbDiscente" runat="server" Text='<%# Eval("NomeDiscente") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbCPF" runat="server" Text='<%# Eval("CPF") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Situação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbSituacaoInscricao" runat="server" Text='<%# Eval("TipoSituacaoInscricao") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nota" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNota" runat="server" Width="95%" Text='<%# Eval("Nota") %>'></asp:TextBox>

                            <asp:MaskedEditValidator
                                ID="MaskedEditValidator1"
                                runat="server"
                                ControlExtender="MaskedEditExtender1"
                                ControlToValidate="txtNota"
                                IsValidEmpty="True"
                                InvalidValueMessage="Valor inválido."
                                MinimumValue="0"
                                MaximumValue="100"
                                Display="Dynamic"
                                ValidationGroup="validationGroup1" />

                            <asp:MaskedEditExtender
                                ID="MaskedEditExtender1"
                                runat="server"
                                MaskType="Number"
                                Mask="?99.99"
                                ClearTextOnInvalid="true"
                                TargetControlID="txtNota"
                                AutoComplete="false"
                                InputDirection="LeftToRight" />

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Conceito" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            
                            <asp:DropDownList ID="ddlConceito" runat="server" >
                                <asp:ListItem Value="">-</asp:ListItem>
                                <asp:ListItem Value="A">A</asp:ListItem>
                                <asp:ListItem Value="B">B</asp:ListItem>
                                <asp:ListItem Value="C">C</asp:ListItem>
                            </asp:DropDownList>

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Título TCC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTituloTCC" runat="server" Width="95%" Text='<%# Eval("TituloTCC") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50%" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <div
                        style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                        <asp:Label ID="lblMsgNenhumRegistro" runat="server"
                            Text="Nenhuma discente cadastrado neste polo para esta turma."></asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </fieldset>

        <div style="text-align: center;">
            <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="False" />
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" SkinID="Nota_Salvar" />
        </div>
    </asp:Panel>


    <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>

    <asp:ModalPopupExtender
        ID="mpePopUp"
        runat="server"
        TargetControlID="lblHidden"
        PopupControlID="pnlImportarNotas"
        CancelControlID="fecharModal"
        BackgroundCssClass="modalBackgroundNotas">
    </asp:ModalPopupExtender>

    <asp:Panel runat="server" ID="pnlImportarNotas" CssClass="modalPopupNotas">

        <h1>
            <asp:Label ID="lblImportarNotas" runat="server">Importar Notas</asp:Label>
        </h1>

        <br />

        <table>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label46" runat="server" Style="font-weight: 700" Text="Documento:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadDocumentoNotas" runat="server" />

                    <br />

                    <span>* O arquivo a ser importado deve ser em formato .CSV</span>
                </td>
            </tr>
        </table>

        <div style="padding: 10px; text-align: center">
            <asp:Button runat="server" ID="importarNotas" OnClick="importarNotas_Click" Text="Importar" />
            <asp:Button runat="server" ID="fecharModal" Text="Cancelar" />
        </div>
    </asp:Panel>

</asp:Content>
