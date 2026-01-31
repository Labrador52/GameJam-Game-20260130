# Level

管理关卡的核心数据与逻辑，包括地图尺寸、回合计数、行动点数和关卡对象。

## 类信息

| 项目 | 内容 |
|------|------|
| 命名空间 | 全局 |
| 继承 | 无 |
| 实现接口 | 无 |

## 成员

### 构造函数

#### Level(Vector2Int size)

初始化关卡实例。

| 参数 | 类型 | 说明 |
|------|------|------|
| size | `Vector2Int` | 关卡地图的尺寸（宽 x 高） |

**初始值：**

- `RoundCount` = 1
- `ActionPointMax` = 5
- `ActionPointCurrent` = `ActionPointMax`

---

### 字段

#### levelObjectMap

| 项目 | 内容 |
| --- | --- |
| 类型 | `LevelObject[,]` |
| 修饰符 | `public readonly` |
| 说明 | 二维数组，存储关卡中各位置的关卡对象 |

---

### 属性

#### Size

| 项目 | 内容 |
|------|------|
| 类型 | `Vector2Int` |
| 访问权限 | get; set; |
| 说明 | 关卡地图的尺寸（宽 x 高） |

#### RoundCount

| 项目 | 内容 |
|------|------|
| 类型 | `int` |
| 访问权限 | get; private set; |
| 说明 | 当前回合数，从 1 开始 |

#### ActionPointCurrent

| 项目 | 内容 |
|------|------|
| 类型 | `int` |
| 访问权限 | get; private set; |
| 说明 | 当前剩余行动点数 |

#### ActionPointMax

| 项目 | 内容 |
|------|------|
| 类型 | `int` |
| 访问权限 | get; private set; |
| 说明 | 每回合最大行动点数 |

#### LevelObjects

| 项目 | 内容 |
|------|------|
| 类型 | `LevelObject[]` |
| 访问权限 | get; private set; |
| 说明 | 关卡中所有关卡对象的数组 |

---

### 方法

#### ExecuteRound()

执行一个回合：依次触发所有关卡对象的回合行动，回合数 +1，并重置行动点。

| 项目 | 内容 |
|------|------|
| 返回值 | `void` |
| 参数 | 无 |

#### TryGetLevelObjectAtPosition(Vector2Int position, out LevelObject levelObject)

尝试获取指定位置的关卡对象。

| 参数 | 类型 | 说明 |
|------|------|------|
| position | `Vector2Int` | 目标位置坐标 |
| levelObject | `out LevelObject` | 输出：该位置的关卡对象（若存在） |

| 项目 | 内容 |
|------|------|
| 返回值 | `bool` |
| 返回说明 | 若位置有效且存在对象返回 `true`，否则返回 `false` |

---

### 事件

无
