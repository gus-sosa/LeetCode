import java.util.Arrays;
import java.util.Comparator;

public class SortThePeople{
    public static void main(String[] args){

    }

    class Solution {
        class Item{
            public String name;
            public int height;

            public Item(String name,int height){
                this.name=name;
                this.height=height;
            }
        }

        class ItemComparator implements Comparator<Item>{

            @Override
            public int compare(Item o1, Item o2) {
                if (o1.height==o2.height){
                    return 0;
                }
                if (o1.height<o2.height){
                    return 1;
                }
                return -1;
            }
        }

        public String[] sortPeople(String[] names, int[] heights) {
            Item[] items=new Item[names.length];
            for (int i = 0; i < names.length; i++) {
                items[i]=new Item(names[i],heights[i]);
            }
            Arrays.sort(items,new ItemComparator());
            String[] retVal=new String[names.length];
            for (int i = 0; i < items.length; i++) {
                retVal[i]=items[i].name;
            }
            return retVal;
        }
    }
}