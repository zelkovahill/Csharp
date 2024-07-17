using System.Threading;

// 1. Thread 생성
// Thread thread = Thread.CurrentThread;
// Console.WriteLine(thread.ThreadState);  // Running

// ============================================================

// 2. Thread 생성
// Thread t = new Thread(threadFunc);
// t.Start();  // ThreadFunc

// static void threadFunc()
// {
//     Console.WriteLine("ThreadFunc");
// }

// ============================================================


// 3. Thread의 정적 메서드 Sleep 메서드
// Console.WriteLine(DateTime.Now);        // 현재 시간 출력
// Thread.Sleep(1000);                                 // 1초 동안 스레드 중지 (1,000ms)
// Console.WriteLine(DateTime.Now);      // 현재 시간 출력

// ============================================================

// 4. 2개의 스레드 실행이 완료된 후 프로그램 종료
// Thread t = new Thread(threadFunc);
// t.Start();
// // 더는 주 스레드가 실행할 명령어가 없으므로 주 스레드는 제거됨

// static void threadFunc()
// {
//     Console.WriteLine("60초 후 프로그램 종료");
//     Thread.Sleep(60000); // 60초 동안 스레드 중지 (60,000ms)
//     Console.WriteLine("스레드 종료");
// }

// ============================================================

// 5. Join 메서드
// Thread t = new Thread(threadFunc);
// t.IsBackground = true;
// t.Start();

// t.Join(); // t 스레드가 종료될 때까지 대기
// Console.WriteLine("스레드 종료");

// static void threadFunc()
// {
//     Console.WriteLine("60초 후에 프로그램 종료");
//     Thread.Sleep(60000); // 60초 동안 스레드 중지 (60,000ms)
//     Console.WriteLine("스레드 종료");
// }


// ============================================================

// Thread t = new Thread(new ParameterizedThreadStart(threadFunc)); // == Thread t = new Thread(threadFunc);
// t.Start(10);

// static void threadFunc(object initialValue)
// {
//     int intValue = (int)initialValue;
//     Console.WriteLine("intValue: " + intValue);
// }

// ============================================================

// class ThreadParam
// {
//     public int Value1;
//     public int Value2;
// }

// class Program
// {
//     static void Main()
//     {
//         Thread t = new Thread(threadFunc);

//         ThreadParam param = new ThreadParam();

//         param.Value1 = 10;
//         param.Value2 = 20;
//         t.Start(param);

//         static void threadFunc(object initialValue)
//         {
//             ThreadParam param = (ThreadParam)initialValue;
//             Console.WriteLine("Value1: " + param.Value1);
//             Console.WriteLine("Value2: " + param.Value2);
//         }
//     }
// }


// ============================================================

// 스레드를 사용한 계산 프로그램
class Program
{


    static void Main()
    {
        Console.WriteLine("입력한 숫자까지의 소수 개수 출력 (종료: 'x' + Enter)");

        while (true)
        {
            Console.Write("숫자 입력 : ");
            string userNumber = Console.ReadLine()!;

            if (userNumber.Equals("x", StringComparison.OrdinalIgnoreCase) == true)
            {
                Console.WriteLine("프로그램 종료");
                break;
            }

            Thread t = new Thread(CountPrimeNumber);
            t.IsBackground = true;
            t.Start(userNumber);
        }
    }

    static void CountPrimeNumber(object initialValue)
    {
        int number = int.Parse((string)initialValue);
        int primeCount = 0;

        for (int i = 2; i <= number; i++)
        {
            bool isPrime = true;

            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime == true)
            {
                primeCount++;
            }
        }

        Console.WriteLine("소수 개수: " + primeCount);
    }

}
// ============================================================