# 線上記帳App
## 專案介紹
TransactionApp是以「開發一款讓一家人一起記帳」的程式為目的記帳系統。\
使用者可以建立帳款紀錄，並依照付款狀態來得知開銷，也可以知道有多少金額未結。\
系統提供完整的 CRUD 功能（新增、修改、刪除、查詢），讓使用者可以方便的對帳款進行查詢與操作。
## 使用技術
1.EntityFramwork連接MS SQL資料庫\
2.以DI注入Ioc來對控制與商業邏輯分層，方便後續維護與更新\
3.使用DTO處理資料以減少多餘資料傳輸，提升效能\
4.使用IValidatableObject模型驗證來確保資料安全與正確性\
5.使用RESTful API架構設計API接口\
## 已實作功能
支出項目管理（新增 / 查詢 / 修改 / 刪除）\
支援多條件查詢（關鍵字、排序、日期區間、支付狀態）\
登入、註冊帳號\
統計查詢結果的總金額(開發中)
## 介面展示
1.登入畫面
<img width="2552" height="1280" alt="image" src="https://github.com/user-attachments/assets/7dd866c0-b566-43b4-aeb7-2d7e8dedf5fc" />
2.註冊畫面
<img width="2547" height="1277" alt="image" src="https://github.com/user-attachments/assets/01151ba6-fcba-4eb9-bdb6-280df9cc8c23" />
3.查詢介面
<img width="2533" height="1269" alt="image" src="https://github.com/user-attachments/assets/c220f1c6-6f0a-45b8-8e74-484ef0453b5d" />
<img width="2546" height="1120" alt="image" src="https://github.com/user-attachments/assets/b5cf3ba3-045d-4490-9d0b-2e22d4b0018d" />
<img width="2547" height="1126" alt="image" src="https://github.com/user-attachments/assets/8b2c4437-e97d-41f0-97c9-41caa18979bf" />
<img width="2541" height="1116" alt="image" src="https://github.com/user-attachments/assets/985f3874-2947-46d1-81d4-3c7b068ac34c" />
4.新增介面
<img width="2551" height="1125" alt="image" src="https://github.com/user-attachments/assets/8db4b824-9daa-49f9-9799-c052d7701a80" />
5.修改介面
<img width="2554" height="1114" alt="image" src="https://github.com/user-attachments/assets/88fa8f86-32d9-4eb9-aca9-bb076dac4dd2" />
6.刪除介面
<img width="2548" height="1117" alt="image" src="https://github.com/user-attachments/assets/e5ef93de-9a30-4632-88b7-6371a8d36fd2" />
