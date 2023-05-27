# Bowling_Kata
### 關於這個套路
#### 參考 [Coding Dojo](https://codingdojo.org/kata/Bowling/).

<hr>

### 專有名詞 / 術語
- 局 (Game)
- 計分格 (Frame)
- 投球 (Roll)
- 全倒 (Strike)：第一球全倒
- 補中 (Spare)：第一球未全倒，第二球全倒
- 完美局 (Perfect Game)：單局最高分都是 300 分，，即連續投出12個 Strike，每個計分格得 30 分
- 火雞 (Turkey)：連續三次全倒
- 洗溝 （Gutter Ball）：球沒有擊中任何球瓶

### 規則
- 一場保齡球賽有 10 局
- 每局有 10 個球瓶，每擊倒 1 個球瓶得 1 分
- 前 9 局每局有 2 顆球
- 第 10 局如果有 Strike 可再打兩球，Spare 可再打一球
- 每局的分數為當局擊倒球瓶數加上 Bonus

### Bonus
- 第 10 局沒有 Bonus。
但 Strike 可再打兩球，Spare 可再打一球。
- Strike：Bonus 為本局分數加下兩球擊倒的瓶數
- Spare：Bonus 為本局分數加下一球擊倒的瓶數