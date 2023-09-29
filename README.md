# Bowling_Kata
### 關於這個套路
- [Coding Dojo](https://codingdojo.org/kata/Bowling/)
- [維基百科](https://zh.wikipedia.org/zh-tw/%E4%BF%9D%E9%BD%A1%E7%90%83)

### 專有名詞 / 術語
- 局 ( Game )
- 計分格 ( Frame )
- 投球 ( Roll )
- 球瓶 ( Pins )
- 全倒 ( Strike )：第一球全倒
- 補中 ( Spare )：第一球未全倒，第二球全倒
- 完美局 ( Perfect Game )：單局最高分都是 300 分，即連續投出 12 個 Strike，每個計分格得 30 分
- 火雞 ( Turkey )：連續三次全倒
- 洗溝 （Gutter Ball）：球沒有擊中任何球瓶

### 規則
- 一場保齡球賽有 10 局
- 每局有 10 個球瓶，每擊倒 1 個球瓶得 1 分
- 前 9 局每局有 2 顆球
- 第 10 局如果有 Strike 可再打兩球，Spare 可再打一球
- 每局的分數為當局擊倒球瓶數加上 Bonus

### Bonus
- Strike：Bonus 為本局分數加下兩球擊倒的瓶數
- Spare：Bonus 為本局分數加下一球擊倒的瓶數
- 第 10 局沒有 Bonus，
但 Strike 可再打兩球，Spare 可再打一球

### 計分劃記符號
| 符號 | 代表意義 |
| :----: | :----: |
| X | 全中 (Strike) |
| / | 補中 (Spare) |
| 1-9 | 擊倒球數 |
| – | 洗溝 (Gutter Ball) |

### 計分板
![](images/score.jpg)
- 第一格
  - 第一次投擲 5 分
  - 第二次投擲 2 分
  - 總得分 7 分 ( 5 + 7 )
- 第二格
  - 第一次投擲 8 分
  - 第二次投擲 Spare
  - Bonus 為下一球擊倒分數
  - 總得分 27 分 ( 7 + 8 + 2 + 10 )
- 第三格
  - 第一次投擲 Strike
  - Bonus 為下兩球擊倒分數
  - 總得分 46 分 ( 27 + 10 + 9 + 0 )
- 第四格
  - 第一次投擲 9 分
  - 第二次投擲 洗溝
  - 總得分 55 分 ( 46 + 9 + 0 )
- 第五格
  - 第一次投擲 Strike
  - Bonus 為下兩球擊倒分數
  - 總得分 75 分 ( 55 + 10 + 10 + 0 )
- 第六格
  - 第一次投擲 Strike
  - Bonus 為下兩球擊倒分數
  - 總得分 95 分 ( 75 + 10 + 0 + 10 )
- 第七格
  - 第一次投擲 洗溝
  - 第二次投擲 Spare
  - Bonus 為下一球擊倒分數
  - 總得分 113 分 ( 95 + 0 + 10 + 8 )
- 第八格
  - 第一次投擲 8 分
  - 第二次投擲 1 分
  - 總得分 122 分 ( 113 + 8 + 1 )
- 第九格
  - 第一次投擲 6 分
  - 第二次投擲 Spare
  - Bonus 為下一球擊倒分數
  - 總得分 138 分 ( 122 + 6 + 4 + 6 )
- 第十格
  - 第一次投擲 6 分
  - 第二次投擲 Spare
  - Spare 可再投擲一球得 10 分
  - 總得分 158 分 ( 138 + 6 + 4 + 10 )

### 測試案例
#### 全部洗溝 (Gutter Game)
| frame | score |
| :----: | :----: |
| -- -- -- -- -- -- -- -- -- -- | 0 |

#### 每次投球都沒有擊倒球瓶 (All roll not knocked down all pins)
| frame | score |
| :----: | :----: |
| 11 11 11 11 11 11 11 11 11 11 | 20 |
| 9- 9- 9- 9- 9- 9- 9- 9- 9- 9- | 90 |
| 43 81 72 22 41 35 23 72 14 62 | 69 |

#### 每球都擊倒10瓶 (Perfect Game)
| frame | score |
| :----: | :----: |
| X X X X X X X X X XXX | 300 |

#### 發生一次 Strike (One Strike)
| frame | score |
| :----: | :----: |
| X 11 11 11 11 11 11 11 11 11 | 30 |
| 11 11 11 X 11 11 11 11 11 11 | 30 |
| 11 11 11 11 11 11 11 11 11 X26 | 36 |

#### 發生一次 Spare (One Spare)
| frame | score |
| :----: | :----: |
| 8/ 11 11 11 11 11 11 11 11 11 | 29 |
| 11 11 3/ 11 11 11 11 11 11 11 | 29 |
| 11 11 11 11 11 11 11 11 11 2/9 | 37 |

#### 隨機賽局 (Random games)
| frame | score |
| :----: | :----: |
| 52 8/ X 9- X X -/ 81 6/ 6/X | 158 |
| 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5 | 150 |
| 6/ X 1- X X -8 9/ 35 4- X34 | 120 |
| X 9/ X 7/ X 2/ X 5/ X 1/X | 200 |
| 14 45 6/ 5/ X -1 7/ 6/ X 27 | 125 |
