# FishingLogViewer

这是钓鱼日志站的公开旧副本，停在 2025-12-09 的提交 `3eb60df`。全部 C# 项目的目标框架是 .NET 9。后来的修改在私人仓库 https://github.com/my9281/fishlog ：主站已是 .NET 10，早期模板在 `archive/`，练习在 `labs/`，旧版 .NET Framework 钓鱼站点在 `legacy/Fishing`。那些提交没有推回这里。本仓库的 Git 历史里有大约 280MB 的大图，工作区本身大约 44MB。

## 这里有什么

解决方案 `FishingLog.sln` 里：

| 目录 | 内容 |
| --- | --- |
| `FishingLogMVC` | 主站。按主机名分 Fishlog、CMS、YMCU、简历和主站。Cookie 登录，LiteDB 存日志，MySQL 走 `user` 和 `note`。 |
| `FishingLog.Model` / `DAL` / `BLL` / `DBUtility` | 上面两张表的数据层。DAL 用 MySQL。 |
| `ReaderInHTML` | 把 changelog HTML 写入 LiteDB。 |
| `frontsideofresume` | React + Vite 简历页。 |
| `AngularProjectFishing` | Angular 20 实验工程，标题仍是默认的 `AngularProjectFishing`。 |

根目录还有五个未进解决方案的早期项目：`FishingLog`（Web API 天气模板）、`Fishlog`（Razor Pages 模板）、`Ymcu`（独立 MVC）、`Fishinglog.BlazorWeb`、`Fishlog.BlazorService`。私人仓库已把它们放进 `archive/`。

## 未完成

- 目标框架仍是 .NET 9，没有 `labs/` 和 `legacy/Fishing`。
- `UsersController` 有写死的访客登录。
- 仓库跟踪了 LiteDB 数据文件 `NoSQLData.DB`、`NoSQLData-log.DB`、`Datadb.db`。
- `appsettings.json` 没有连接串。要用数据库时自己配，不要把口令提交进来。
