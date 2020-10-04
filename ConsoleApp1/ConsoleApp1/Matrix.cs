using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;


public class Matrix
{

	private const int highestRand = 10;
	List<List<double>> mat;
	public Matrix(List<List<double>> inputs)
	{
		mat = inputs;
		if (DimensionCheck()) {}
		else {
			Console.WriteLine("Incorrect dimensions for a matrix!");

		};
	}

	public Matrix(int rows, int columns)
    {
		mat = new List<List<double>>();
		List<double> tempRow;
		var rand = new Random();
		for (int i = 0; i < rows; i++)
		{
			tempRow = new List<double>();
			for (int j = 0; j < columns; j++)
			{
				tempRow.Add(rand.Next(highestRand));
			}

			mat.Add(tempRow);
		}
    }

	public bool DimensionCheck()
    {
		foreach(var i in mat)
        {
			if (mat[0].Count != i.Count)
			{
				return false;
			}
			else {}
        }

		return true;
    }

	public List<int> Size()
    {
		int column = mat[0].Count;
		int row = mat.Count;

		List<int> dimensions = new List<int>();
		dimensions.Add(row);
		dimensions.Add(column);

		return dimensions;
    }

	
	public void ChangeMat(List<List<double>> inputs)
    {
		mat = inputs;

    }

	public void AddRow(List<double> newRow)
    {
		mat.Add(newRow);
        if (DimensionCheck()) {}
		else
        {
			Console.WriteLine("Incorrect dimensions for a matrix!");
        }
    }

	public void AddColumn(List<double> newColumn)
    {
		List<List<double>> tempMat = new List<List<double>>();
		List<double> tempRow = new List<double>();

		for(int i = 0; i < mat.Count; i++)
        {
			tempRow = mat[i];
			tempRow.Add(newColumn[i]);
			mat[i] = tempRow;
        }

		if(mat.Count != newColumn.Count)
        {
			Console.WriteLine("Attempted input would have given incorrect dimensions for a matrix!");
        }
    }

	public double access(int row, int column)
    {
		return mat[row - 1][column - 1];
    }

	public void printMatrix()
    {
		foreach(var i in mat)
        {
			foreach(var j in i)
            {
				Console.Write(j + " ");
            }
			Console.WriteLine();
        }
    }

   

    public List<double> getRow(int row)
    {
		int corrRow = row - 1;
		return mat[corrRow];
    }

	public List<double> getColumn(int column)
	{
		int corrColumn = column - 1;
		List<double> output = new List<double>();

		for (int i = 0; i < mat.Count; i++)
		{
			output.Add(mat[i][corrColumn]);
		}

		return output;

	}

	public void Transpose()
    {
		List<List<double>> tempMat = new List<List<double>>();
		for(int i = 1; i <= mat[0].Count; i++)
        {
			tempMat.Add(getColumn(i));
        }

		mat = tempMat;
    }

	public List<double> multiplication(List<double> vector)
    {
		List<double> product = new List<double>();
		double element;
		foreach(var i in mat)
        {
			element = 0;
			for(int j = 0; j < mat[0].Count; j++)
            {
				element += i[j] * vector[j];
            }
			product.Add(element);
        }

		return product;
    }

	public static List<double> AddLists(List<double> one, List<double> two)
    {
		List<double> sum = new List<double>();
		for(int i = 0; i < one.Count; i++)
        {
			sum.Add(one[i] + two[i]);
        }

		return sum;
    }


	

}
