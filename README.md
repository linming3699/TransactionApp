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
<img width="2553" height="1273" alt="image" src="https://github.com/user-attachments/assets/b11be54c-9205-46eb-8568-0005755f4af9" />
2.註冊畫面
<img width="2546" height="1275" alt="image" src="https://github.com/user-attachments/assets/204d512c-cc92-4979-84ab-e2bf41123ee8" />
3.查詢介面
<img width="2539" height="1274" alt="image" src="https://github.com/user-attachments/assets/a281fa65-d7ff-44b6-9986-93f0f76b7199" />
<img width="2546" height="1267" alt="image" src="https://github.com/user-attachments/assets/b7b657da-c660-4d2b-ad74-1863521f2745" />
<img width="2545" height="1272" alt="image" src="https://github.com/user-attachments/assets/8a147b91-ae4e-422d-becd-b4cdbb13895d" />
<img width="2543" height="1271" alt="image" src="https://github.com/user-attachments/assets/e1e99c6c-257f-4140-aca9-c011e9f4abd9" />
4.新增介面
<img width="2547" height="1120" alt="image" src="https://github.com/user-attachments/assets/eee344ac-5ccf-457e-a33d-e0a6415aaddf" />
5.修改介面
<img width="2551" height="1117" alt="image" src="https://github.com/user-attachments/assets/b34f9f2e-84df-42bd-b1c2-978ee7e78ac9" />
6.刪除介面
<img width="2542" height="1120" alt="image" src="https://github.com/user-attachments/assets/e54d3726-0271-408d-be37-7542a85398d1" />
