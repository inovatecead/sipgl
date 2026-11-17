# ufmt.sipgl

Sistema web da UFMT (Universidade Federal de Mato Grosso) para gestão de
pós-graduação lato sensu. Este repositório contém o código-fonte completo em
C#, o modelo de dados completo, e um projeto Web pronto para build no Visual
Studio.

> **Status**: 5 das 5 bibliotecas compilam limpas (0 erros). O projeto Web
> (WebForms clássico) só pode ser compilado/testado no Windows — ver
> [Status do build](#status-do-build).

## Sumário

- [O que é este sistema](#o-que-é-este-sistema)
- [Arquitetura](#arquitetura)
- [Estrutura do repositório](#estrutura-do-repositório)
- [Status do build](#status-do-build)
- [Configuração (credenciais e segredos)](#configuração-credenciais-e-segredos)
- [Requisitos mínimos — Ambiente de Testes](#requisitos-mínimos--ambiente-de-testes)
- [Requisitos mínimos — Ambiente de Produção](#requisitos-mínimos--ambiente-de-produção)
- [Pontos de atenção antes de ir para produção](#pontos-de-atenção-antes-de-ir-para-produção)
- [Limitações conhecidas](#limitações-conhecidas)
- [Licenciamento de componentes de terceiros](#licenciamento-de-componentes-de-terceiros)

## O que é este sistema

Com base nas entidades do modelo de dados, nos nomes de página e nas
configurações do sistema (`appSettings["Sistema"] = "STI/UFMT"`), este é um
sistema de **gestão de pós-graduação lato sensu** (cursos de especialização,
não cursos de mestrado/doutorado stricto sensu) da UFMT. Não há documentação
de negócio oficial disponível; esta conclusão é inferida a partir do próprio
código.

Evidências que sustentam essa leitura:

- Entidades centrais: `Discente`, `Docencia`, `Curso`, `Coordenador`,
  `EstruturaCurricular`, `MatrizCurricular`, `Historico`, `Horario`,
  `PlanoPedagogico`;
- Entidades ligadas a cursos de especialização financiados por convênio:
  `ProjetoCursoPresencial`, `InstituicaoConvenio`,
  `ProjetoBolsaEstagioLei_11788_2008` (Lei do Estágio),
  `ProjetoBolsaoLei_8958_94` (Lei de convênios universidade-fundação — comum
  em cursos de especialização pagos/com convênio no Brasil);
- Telas de portal do aluno: cadastro, matrícula, alteração de dados,
  confirmação de e-mail, recuperação de senha (`aluno/`, `webapp/discente/`);
- Relatórios institucionais: notas, frequência, histórico escolar, lista de
  matrículas por disciplina/turma.

O sistema depende de outro sistema institucional da UFMT, `ufmt.sig`
("Sistema de Informações Gerenciais"), que fornece
autenticação, cadastro de pessoas/servidores e controle de permissões —
usado aqui só como biblioteca de apoio (login, dados de pessoa/docente), não
como aplicação própria.

## Arquitetura

```
┌─────────────────────────────────────────────────────────────┐
│  ufmt.sipgl.Web  (ASP.NET WebForms, .NET Framework 4.8)      │
│  — 77 páginas .aspx + code-behind, Master Pages, 2 Web       │
│    Services (.asmx), relatórios em PDF/Excel (PdfSharp/      │
│    MigraDoc + ClosedXML), upload de arquivos, autenticação   │
│    por Forms + Web Reference SOAP                            │
└───────────────┬─────────────────────────┬─────────────────────┘
                │                         │
                ▼                         ▼
┌───────────────────────────┐   ┌─────────────────────────────┐
│ ufmt.sipgl.Business        │   │  ufmt.sig                    │
│ (regras de negócio)        │◄──┤  (pessoas, permissões, login, │
│                             │   │   NHibernate)                 │
└───────────────┬─────────────┘   └───────────────┬───────────────┘
                │                                 │
                ▼                                 ▼
┌───────────────────────────┐   ┌─────────────────────────────┐
│ ufmt.sipgl.DataAccess       │   │  ufmt.nhibernate              │
│ (Entity Framework,          │   │  (infraestrutura de sessão    │
│  135 entidades, SQL Server) │   │   NHibernate p/ ufmt.sig)     │
└─────────────────────────────┘   └─────────────────────────────┘

┌─────────────────────────────┐
│ ufmt.utils                   │  biblioteca auxiliar com uma
│ (implementação parcial)       │  funcionalidade pendente (ver
└─────────────────────────────┘   Limitações conhecidas)
```

**Duas camadas de persistência coexistem** (não é uma inconsistência, é
intencional):

- **Entity Framework** (`ufmt.sipgl.DataAccess`) — modelo próprio do SIPGL,
  135 entidades, contra o banco `idbufmt` em SQL Server;
- **NHibernate** (`ufmt.sig` + `ufmt.nhibernate`) — modelo do sistema
  institucional, 68 mapeamentos `.hbm.xml`, mesmo banco `idbufmt`.

**Front-end**: ASP.NET WebForms puro (Web Forms + Master Pages +
AjaxControlToolkit para componentes assíncronos), sem SPA/framework
JavaScript moderno — scripts estáticos em `Scripts/`.

**Relatórios**: gerados em código com **PdfSharp + MigraDoc** (PDF) e
**ClosedXML** (Excel), ambas MIT — notas, disciplinas, frequência,
matrículas (PDF e Excel), histórico escolar e notas do aluno.

**Integração externa**: um Web Reference SOAP (`br.ufmt.sistemas.Autenticacao`)
contra um serviço de autenticação institucional da UFMT, fora deste
repositório.

## Estrutura do repositório

```
README.md             Este arquivo
Model.edmx             Modelo completo do Entity Framework (135 entidades)
ufmt.sipgl.slnx         Solução com os 5 projetos
libs/                   Binários de terceiros sem pacote NuGet equivalente
                        compatível (EntityFramework, CsvHelper, NHibernate,
                        ExcelDataReader) — todos open source, ver
                        Licenciamento
src/
├── ufmt.sipgl.Web/        ★ projeto Web — abrir no Visual Studio
├── ufmt.sipgl.Business/   regras de negócio
├── ufmt.sipgl.DataAccess/ acesso a dados (Entity Framework)
├── ufmt.sig/              sistema institucional (NHibernate)
├── ufmt.nhibernate/       infraestrutura de sessão NHibernate
└── ufmt.utils/            biblioteca auxiliar (ver limitações)
```

## Status do build

| Projeto | Compila |
|---|---|
| `ufmt.nhibernate` | ✅ validado (`dotnet build`, 0 erros) |
| `ufmt.utils` | ✅ validado |
| `ufmt.sig` | ✅ validado |
| `ufmt.sipgl.Business` | ✅ validado |
| `ufmt.sipgl.DataAccess` | ✅ validado |
| `ufmt.sipgl.Web` | ⚠️ não validável fora do Windows — WebForms clássico exige .NET Framework completo no Windows |

A geração de relatórios (`ufmt.sipgl.Web/_Helpers/.../relatorios/`) foi
validada isoladamente: as classes `RelatorioPdfBuilder`, `RelatorioExcelBuilder`
e `RelatorioResponseExtensions` compilam com 0 erros contra as versões reais
dos pacotes (`PDFsharp-MigraDoc` 6.5.0, `ClosedXML` 0.102.2).

## Configuração (credenciais e segredos)

**Os arquivos de configuração deste repositório não contêm credenciais
reais** — os valores foram substituídos por placeholders. Isso inclui:

- Connection string do SQL Server (`Web.config`, `app.config` da
  `ufmt.sipgl.DataAccess`) — host, usuário e senha reais substituídos por
  `__DB_HOST__`, `__DB_PORT__`, `__DB_INSTANCE__`, `__DB_USER__`,
  `__DB_PASSWORD__`;
- Credenciais de SMTP (`Web.config` → `appSettings`) — host, usuário e senha
  reais substituídos por `__SMTP_HOST__`, `__SMTP_USER__`,
  `__SMTP_PASSWORD__`, `__SMTP_FROM_ADDRESS__`;
- Uma senha e um IP de servidor SMTP que estavam **hardcoded direto no
  código-fonte** (`ufmt.sig/.../AutenticacaoBO.cs`, fora de qualquer arquivo
  de config) — removidos e substituídos por leitura de `appSettings`.

Antes de rodar em qualquer ambiente, preencha esses valores. **Nunca
commite um valor real** — use:

- Variável de ambiente, ou
- `Web.config` local não versionado (adicione ao `.gitignore`), ou
- Transform de configuração por ambiente (`Web.Release.config`, Azure App
  Settings, variável de ambiente do IIS, etc.), ou
- Um secret manager/cofre, se o ambiente de produção já tiver um.

## Requisitos mínimos — Ambiente de Testes

| Item | Requisito |
|---|---|
| Sistema operacional | Windows 10/11 ou Windows Server 2012 R2+ |
| IDE / build | Visual Studio 2017 ou superior (com carga de trabalho "Desenvolvimento ASP.NET e web") |
| Runtime | .NET Framework 4.8 |
| Servidor web | IIS Express (incluso no Visual Studio) é suficiente para testes locais |
| Banco de dados | SQL Server 2008 ou superior (dialeto NHibernate configurado é `CustomMsSql2008Dialect`) — Express/Developer Edition serve para testes |
| SMTP | Qualquer servidor SMTP acessível (ou um fake SMTP local, tipo Papercut/smtp4dev, para não enviar e-mails reais durante teste) |
| Armazenamento de arquivos | Diretório local em disco (`diretorioUpload`, `diretorioUploadEditais` em `appSettings`) — não usa S3/Blob Storage |
| Componentes de terceiros | Todos vêm via NuGet automaticamente, exceto os binários em `libs/` (sem pacote NuGet compatível com os `TargetFramework` originais) — restaurados junto com o build |

## Requisitos mínimos — Ambiente de Produção

| Item | Requisito |
|---|---|
| Sistema operacional | Windows Server 2012 R2+ com IIS 8+ habilitado |
| Runtime | .NET Framework 4.8 instalado no servidor (role/feature do Windows) |
| Banco de dados | SQL Server 2008+ dedicado, com usuário de aplicação com permissão restrita ao banco `idbufmt` (não usar `sa`) |
| TLS/HTTPS | Certificado válido configurado no IIS — a aplicação usa Forms Authentication, que **exige HTTPS** para não expor credenciais/cookies de sessão em texto plano |
| SMTP | Servidor SMTP de produção da instituição, com credencial dedicada (não reaproveitar credencial de teste) |
| Armazenamento de arquivos | Disco com espaço e política de backup adequados aos caminhos de upload configurados; `maxRequestLength` está em `1048576` (≈1 GB) — validar se esse limite é realmente necessário em produção |
| Processo de deploy | Build via MSBuild/Visual Studio → publish para IIS. Não há pipeline de CI/CD neste repositório; precisa ser criado |
| Segredos | Mecanismo de gestão de segredos do ambiente de produção (cofre, variável de ambiente do IIS App Pool, etc.) — nunca o `Web.config` versionado |

Todas as dependências de terceiros usadas pela aplicação são open source.
Ver [Licenciamento](#licenciamento-de-componentes-de-terceiros).

## Pontos de atenção antes de ir para produção

Estes comportamentos já estão presentes na configuração atual e merecem
revisão antes de expor o sistema publicamente:

- **`<customErrors mode="Off">`** (`Web.config`) — desabilita a página de
  erro amigável e expõe stack trace completo para qualquer usuário em caso
  de exceção não tratada. Recomendado mudar para `RemoteOnly` ou `On` em
  produção.
- **`<roleManager enabled="false">`** — o provedor de roles do ASP.NET
  Membership está desabilitado; confirmar se o controle de acesso realmente
  acontece só via `ufmt.sig`/permissões próprias antes de assumir que não há
  lacuna de autorização.
- **`forms loginUrl="~/Account/Login.aspx"`** não corresponde a nenhuma
  página real do projeto (a tela de login real é `Login/Autenticar.aspx`) —
  parece um resíduo de template não ajustado; validar o fluxo de redirect de
  autenticação.

## Limitações conhecidas

A biblioteca `ufmt.utils` tem implementação mínima para duas funcionalidades:

- `ufmt.utils.extension.StringBuilderExtension` — implementação simples de
  um helper de concatenação com separador. Risco baixo.
- `ufmt.utils.mail.Mail.SendMail` — **não implementada**. Existe como stub
  que lança `NotImplementedException`. É necessário implementar o envio
  real de e-mail (SMTP, tratamento de erro) antes de usar em produção. Veja
  `src/ufmt.utils/ufmt/utils/mail/Mail.cs`.

Os **7 relatórios** (PDF/Excel) são gerados em código. Fontes, espaçamento e
quebras de página podem variar ligeiramente dependendo do ambiente de
renderização. Revise a saída de cada relatório antes de considerar o
ambiente pronto para produção.

## Licenciamento de componentes de terceiros

Todas as dependências de terceiros usadas por este repositório são open
source com licenças permissivas:

| Biblioteca | Licença | Uso |
|---|---|---|
| NHibernate | LGPL 2.1 | ORM (`ufmt.sig`) |
| Entity Framework | Apache 2.0 / MIT | ORM (`ufmt.sipgl.DataAccess`) |
| log4net | Apache 2.0 | Logging |
| AjaxControlToolkit | BSD | Controles WebForms assíncronos |
| CsvHelper | MS-PL / Apache 2.0 | Importação de CSV |
| ExcelDataReader | MIT | Leitura de planilhas |
| PDFsharp-MigraDoc | MIT | Geração de relatórios em PDF |
| ClosedXML | MIT | Geração de relatórios em Excel |

Não há dependências comerciais/restritivas neste repositório, o que é
relevante caso a UFMT decida licenciar este repositório sob uma licença
aberta (GPL, MIT, Apache 2.0 etc.) — essa decisão é institucional e deve
ser tomada pelo NIT/Procuradoria da universidade, não está definida neste
repositório.
