package HandOfStraights;

import java.util.Arrays;
import java.util.stream.Collectors;
import java.util.List;

class Solution {
    class Node<T> {
        T data;
        Node<T> next;

        Node(T x) {
            data = x;
            next = null;
        }
    }

    class LinkedList<T> {
        Node<T> head;
        Node<T> tail;

        LinkedList() {
            head = null;
            tail = null;
        }

        LinkedList(List<T> arr) {
            head = new Node<T>(arr.get(0));
            tail = head;
            for (int i = 1; i < arr.size(); ++i) {
                tail.next = new Node<T>(arr.get(i));
                tail = tail.next;
            }
        }

        void add(T x) {
            if (head == null) {
                head = new Node<T>(x);
                tail = head;
                return;
            }
            tail.next = new Node<T>(x);
            tail = tail.next;
        }

        void addLinkedListToEnd(LinkedList<T> list) {
            if (head == null) {
                head = list.head;
                tail = list.tail;
                return;
            }
            tail.next = list.head;
            tail = list.tail;
        }

        T poll() {
            if (head == null) {
                throw new RuntimeException("Cannot poll from empty list");
            }
            T data = head.data;
            head = head.next;
            return data;
        }

        boolean isEmpty() {
            return head == null;
        }

        void empty() {
            head = null;
            tail = null;
        }
    }

    public boolean isNStraightHand(int[] hand, int groupSize) {
        if (hand.length % groupSize != 0) {
            return false;
        }

        Arrays.sort(hand);
        LinkedList<Integer> handList = new LinkedList<>(Arrays.stream(hand).boxed().collect(Collectors.toList()));
        LinkedList<Integer> helperList = new LinkedList<>();
        int lastElementInGroup = 0;
        int numberOfElementsInGroup = 0;

        while (!handList.isEmpty()) {
            if (numberOfElementsInGroup == groupSize) {
                numberOfElementsInGroup = 0;
                helperList.addLinkedListToEnd(handList);
                handList.empty();
                handList.addLinkedListToEnd(helperList);
                helperList.empty();
                continue;

            }
            int current = handList.poll();
            if (numberOfElementsInGroup == 0) {
                lastElementInGroup = current;
                ++numberOfElementsInGroup;
                continue;
            }
            if (current == lastElementInGroup) {
                helperList.add(current);
                continue;
            }
            if (current == lastElementInGroup + 1) {
                lastElementInGroup = current;
                ++numberOfElementsInGroup;
                continue;
            }
            return false;
        }

        return handList.isEmpty() && helperList.isEmpty() && numberOfElementsInGroup == groupSize;
    }
}