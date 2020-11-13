subtree(子树)和submodule(子模块)的区别:

添加子模块时会添加一个多的submodule文件在仓库中,修改子模块部分时候需要切换到子模块中提交,远程分支的主仓库和子模块都更新的情况下只拉取主仓库会出现子模块的head丢失的问题,因为现在主仓库中的子模块head信息超前了本地仓库,更新子模块后恢复正常,相当于每次更新都需要把所有子模块都拉取一次,如果忘记拉取会导致子模块提交丢失等一系列问题,

子树直接以一次合并的commit添加到当前仓库中,不会产生多余的文件,当修改的文件涉及到子树,子树推送时,会搜索所有的commit,找出针对子树的更改,只推送这部分. 子树相当于主仓库的一部分,但可以单独拉取和推送.

**疑问:从远程仓库拉取时如何分辨仓库中是否有子树?**

[子树介绍](https://www.jianshu.com/p/3096069e9b72)

**submodule 与 subtree对比**

- git submodule
  - 允许其他的仓库指定以一个commit嵌入仓库的子目录
  - 仓库 `clone`下来需要 `init` 和 `update`
  - 会产 `.gitmodule` 文件记录 submodule 版本信息
  - git submodule 删除起来比较费劲
- git subtree
  - 避免以上问题
  - 管理和更新流程比较方便
  - git subtree合并子仓库到项目中的子目录。不用像submodule那样每次子项目修改了后要`init`和`update` 。万一哪次没update就直接`add .` 将`.gitmodule` 也 `commit`上去就悲剧了
  - git v1.5.2以后建议使用git subtree



作者：Archerlly
链接：https://www.jianshu.com/p/3096069e9b72
来源：简书
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。