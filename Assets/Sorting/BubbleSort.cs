using UnityEngine;
using System.Collections;

public class BubbleSort : Sorter {

	
	public override void StartSort ()
	{
		StartCoroutine(DoSortNow());	
	}
	
	public IEnumerator DoSortNow(){
		Debug.Log ("Started DoSortNow()");
		yield return new WaitForSeconds(2);
		Debug.Log("Done Waiting");
		
		bool hasSwap = true;
		
		while(hasSwap == true){
			// possibly end the loop at the end
			hasSwap = false;
			
			for(int i=0;i<arrayToSort.Length-1;i++){
				
				int leftItem = arrayToSort[i];
				int rightItem = arrayToSort[i+1];
				
				if(leftItem > rightItem){
					arrayToSort[i] = rightItem;
					arrayToSort[i+1] = leftItem;
					hasSwap = true;
					
				}
				yield return new WaitForSeconds(0.125f);
				
			}
			yield return new WaitForSeconds(1);
			
		}
		
		Debug.Log ("SORTING COMPLETE");
		
	}
	
	
	
	
	
	
	
}
