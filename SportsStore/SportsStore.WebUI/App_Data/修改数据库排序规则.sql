-- 修改数据库排序规则，使之兼容简体中文
-- 注意修改时需要断开数据库连接
alter database [D:\project_files\ProMVC5_20180922\SportsStore\SportsStore.WebUI\App_Data\SportsStore.mdf] collate Chinese_PRC_CI_AS;
go