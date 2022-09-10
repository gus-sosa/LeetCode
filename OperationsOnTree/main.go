package main

func main() {

}

type LockingTree struct {
	parents []int
	locks   []int
	nodes   []*Tree
}

type Tree struct {
	val      int
	children []*Tree
}

func Constructor(parent []int) LockingTree {
	return LockingTree{
		parents: parent,
		locks:   make([]int, len(parent)),
		nodes:   buildTree(parent),
	}
}

func buildTree(parent []int) []*Tree {
	nodes := make([]*Tree, len(parent))
	for i := 0; i < len(parent); i++ {
		nodes[i] = &Tree{
			val: i,
		}
	}
	for i, p := range parent {
		if i == 0 {
			continue
		}
		nodes[p].children = append(nodes[p].children, nodes[i])
	}
	return nodes
}

func (this *LockingTree) isLocked(num int) bool {
	return this.locks[num] != 0
}

func (this *LockingTree) Lock(num int, user int) bool {
	if this.isLocked(num) {
		return false
	}
	this.locks[num] = user
	return true
}

func (this *LockingTree) Unlock(num int, user int) bool {
	if this.locks[num] == user {
		this.locks[num] = 0
		return true
	}
	return false
}

func (this *LockingTree) Upgrade(num int, user int) bool {
	if !this.isLocked(num) && this.HasOneLockedDescendent(this.nodes[num]) && !this.HasLockedAncestor(num) {
		this.UnlockAll(num)
		this.locks[num] = user
		return true
	}
	return false
}

func (this *LockingTree) UnlockAll(num int) {
	this.locks[num] = 0
	for _, child := range this.nodes[num].children {
		this.UnlockAll(child.val)
	}
}

func (this *LockingTree) HasLockedAncestor(node int) bool {
	if node == 0 {
		return this.isLocked(0)
	}
	if this.isLocked(node) {
		return true
	}
	return this.HasLockedAncestor(this.parents[node])
}

func (this *LockingTree) HasOneLockedDescendent(t *Tree) bool {
	if t == nil {
		return false
	}
	if this.isLocked(t.val) {
		return true
	}
	for _, child := range t.children {
		if this.HasOneLockedDescendent(child) {
			return true
		}
	}
	return false
}

/**
 * Your LockingTree object will be instantiated and called as such:
 * obj := Constructor(parent);
 * param_1 := obj.Lock(num,user);
 * param_2 := obj.Unlock(num,user);
 * param_3 := obj.Upgrade(num,user);
 */
