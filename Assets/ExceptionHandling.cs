using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExceptionHandling : MonoBehaviour
{

    int a,b,licence;

    // Start is called before the first frame update
    void Start()

    {
        // int c = a/b;
        // print("c ans");
        try{
            checklicence(19,true,false);
        }

        catch(Exception e){
            print(e.Message);
        }

        finally{
          checklicence(19,true,true);
          print("Passed");
        }
        print("Run this line of code");
    }

    void checklicence(int age, bool passedWrittenExam, bool passedTrial){
        if(age<18||!passedWrittenExam||!passedTrial )throw new Exception("Doest have licence");

    }
}
