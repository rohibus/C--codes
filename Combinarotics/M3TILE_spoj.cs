using System;
					
public class Program
{
	public static void Main()
	{
		M3TILE m = new M3TILE();
	}
	
	public class M3TILE
	{
		public M3TILE()
		{
			int choice;
			do
			{
				choice = Convert.ToInt32(Console.ReadLine());
				long ans = Solve(choice);
				if (choice != -1)
					Console.WriteLine(ans);
			} while(choice != -1);
		}
		
		public long Solve(int n)
		{
			if (n < 2)
				return 0;
          	if (n % 2 == 1)
              return 0;
			
			long[] fn = new long[n+1];
			long[] gn = new long[n+1];
			
			fn[0] = gn[0] = 1;
			fn[1] = gn[1] = 1;
			
			for (int i = 2; i <= n; i++)
			{
				fn[i] = fn[i-2] + 2*gn[i-2];
				gn[i] = fn[i] + gn[i-2];
			}
			
			return fn[n];
		}
	}
}