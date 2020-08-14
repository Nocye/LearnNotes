unity中的update  fixupdate OnCollisionEnter的执行顺序是不确定的,如果有需要在两种轮询函数中判断的条件,不要在onEnter这类函数中更改,因为无法确定他们的执行顺序是在轮询函数之前或者之后,会导致 

Update中输入,且根据条件给力->fixUpdate中给force->OnEnter检测到碰撞修改条件       这样的模拟逻辑变为

Update中检测输入,且根据条件给力->fixUpdate中给force,->Update根据条件给力,此时OnEnter未执行,条件没改变,计划给的的力重置->OnExit执行,改变条件,但此事力已被重置,



出现这问题表明自己对Unity的生命函数不够了解,且代码逻辑有问题,在同一个轮询函数中判断的逻辑也需要在同一个轮询函数中修改,以后需要牢记