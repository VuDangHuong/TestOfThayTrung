<?php

namespace App\Http\Controllers;

use App\Models\Category;
use Illuminate\Http\Request;

class CategoryController extends Controller
{
    public function index()
    {
        $categories = Category::orderBy('MaCategory', 'desc')->get();
        return view('categories.index', compact('categories'));
    }

    public function create()
    {
        return view('categories.create');
    }

    public function store(Request $request)
    {
        $request->validate([
            'Name' => 'required|string|max:255|unique:Category,Name',
            'Description' => 'required|string|max:255'
        ]);

        $category = new Category();
        $category->Name = $request->Name;
        $category->Description = $request->Description;
        $category->CreatedAt = now();
        $category->UpdatedAt = now();
        $category->save();

        return redirect()->route('categories.index')->with('success', 'Category created successfully.');
    }

    public function edit(Category $category)
    {
        return view('categories.edit', compact('category'));
    }

    public function update(Request $request, Category $category)
    {
        $request->validate([
            'Name' => 'required|string|max:255|unique:Category,Name,' . $category->MaCategory . ',MaCategory',
            'Description' => 'required|string|max:255'
        ]);

        $category->Name = $request->Name;
        $category->Description = $request->Description;
        $category->UpdatedAt = now();
        $category->save();

        return redirect()->route('categories.index')->with('success', 'Category updated successfully.');
    }

    public function destroy(Category $category)
    {
        $category->delete();
        return redirect()->route('categories.index')->with('success', 'Category deleted successfully.');
    }

    public function bulkDelete(Request $request)
    {
        $ids = $request->input('ids', []);
        if (!empty($ids)) {
            Category::whereIn('MaCategory', $ids)->delete();
            return redirect()->route('categories.index')->with('success', 'Selected product groups have been deleted!');
        }
        return redirect()->route('categories.index')->with('success', 'No product group has been selected!');
    }
} 