<?php

namespace App\Http\Controllers;

use App\Models\Product;
use App\Models\Category;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    public function index(Request $request)
    {
        $query = Product::with('category');
        
        if ($request->has('category_id') && $request->category_id != '') {
            $query->where('MaCategory', $request->category_id);
        }
        
        $products = $query->orderBy('MaProduct', 'desc')->get();
        $categories = Category::all();
        
        return view('products.index', compact('products', 'categories'));
    }

    public function create()
    {
        $categories = Category::all();
        return view('products.create', compact('categories'));
    }

    public function store(Request $request)
    {
        $request->validate([
            'Name' => 'required|string|max:255|unique:Product,Name',
            'Price' => 'required|integer|min:0',
            'Quantity' => 'required|integer|min:0',
            'Description' => 'nullable|string',
            'MaCategory' => 'required|exists:Category,MaCategory'
        ]);

        $product = new Product();
        $product->Name = $request->Name;
        $product->Price = $request->Price;
        $product->Quantity = $request->Quantity;
        $product->Description = $request->Description;
        $product->MaCategory = $request->MaCategory;
        $product->CreatedAt = now();
        $product->UpdatedAt = now();
        $product->save();

        return redirect()->route('products.index')->with('success', 'Product created successfully.');
    }

    public function edit(Product $product)
    {
        $categories = Category::all();
        return view('products.edit', compact('product', 'categories'));
    }

    public function update(Request $request, Product $product)
    {
        $request->validate([
            'Name' => 'required|string|max:255|unique:Product,Name,' . $product->MaProduct . ',MaProduct',
            'Price' => 'required|integer|min:0',
            'Quantity' => 'required|integer|min:0',
            'Description' => 'nullable|string',
            'MaCategory' => 'required|exists:Category,MaCategory'
        ]);

        $product->Name = $request->Name;
        $product->Price = $request->Price;
        $product->Quantity = $request->Quantity;
        $product->Description = $request->Description;
        $product->MaCategory = $request->MaCategory;
        $product->UpdatedAt = now();
        $product->save();

        return redirect()->route('products.index')->with('success', 'Product updated successfully.');
    }

    public function destroy(Product $product)
    {
        $product->delete();
        return redirect()->route('products.index')->with('success', 'Product deleted successfully.');
    }

    public function bulkDelete(Request $request)
    {
        $ids = $request->input('ids', []);
        if (!empty($ids)) {
            Product::whereIn('MaProduct', $ids)->delete();
            return redirect()->route('products.index')->with('success', 'Selected product groups have been deleted!');
        }
        return redirect()->route('products.index')->with('success', 'No product group has been selected!');
    }
} 