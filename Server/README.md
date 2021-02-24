# 后端接口：

# 数据设计：
  1. 表：LeftTab  存储 LeftBox 选项列列表。
  2. 表：RightTab 存储 LeftBox 选中的列表。
# 数据库初始脚本
  
  database/Database-Init.sql

# 后端：.netcore3.1+webapi+swagger+EFCore

# 引入包

Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Swashbuckle.AspNetCore

# 版本管理，初始数据表
Add-Migration Initial
Update-Database

# 接口实现：TabController

  1.构造函数中初始数据

  接口1：获取LeftTab 列表  https://localhost:5001/api/Tab    

  接口2:  https://localhost:5001/api/Tab/1

  接口3:  保存选择发送的数据到 表：RightTab
  
  https://localhost:5001/api/Tab/SaveData
  [
    {
      "id": 0,
      "repoTitle": "boat-house-frontend",
      "repoDesp": "IDCF Boat House 前端库，包括用户界面 和 管理界面",
      "repoUrl": "https://github.com/idcf-boat-house/boat-house-frontend",
      "sendMail": "zmy@ata.net.cn",
      "sendTime": "2021-02-24T12:35:51.999Z"
    }
  ]



接口调试：  
https://localhost:5001/swagger/index.html