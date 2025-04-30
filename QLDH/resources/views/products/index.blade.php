@extends('layouts.app')

@section('title', 'Products')

@section('content')
<div class="row mb-4">
    <div class="col-md-6">
        <h2>Products</h2>
    </div>
    <div class="col-md-6 text-end">
        <a href="{{ route('products.create') }}" class="btn btn-primary">
            <i class="bi bi-plus-circle"></i> Add New Product
        </a>
    </div>
</div>

<div class="card mb-4">
    <div class="card-body">
        <form action="{{ route('products.index') }}" method="GET" class="row g-3">
            <div class="col-md-4">
                <label for="category_id" class="form-label">Filter by Category</label>
                <select name="category_id" id="category_id" class="form-select" onchange="this.form.submit()">
                    <option value="">All Categories</option>
                    @foreach($categories as $category)
                        <option value="{{ $category->MaCategory }}" {{ request('category_id') == $category->MaCategory ? 'selected' : '' }}>
                            {{ $category->Name }}
                        </option>
                    @endforeach
                </select>
            </div>
        </form>
    </div>
</div>

@if(session('success'))
    <div class="alert alert-success alert-dismissible fade show" role="alert">
        {{ session('success') }}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
@endif

<form action="{{ route('products.bulk-delete') }}" method="POST" id="bulk-delete-form">
    @csrf
    @method('DELETE')
    <div class="mb-2">
        <button type="submit" class="btn btn-danger btn-sm" onclick="return confirm('Bạn có chắc chắn muốn xóa các sản phẩm đã chọn?')">
            <i class="bi bi-trash"></i> Xóa đã chọn
        </button>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th><input type="checkbox" id="select-all"></th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Category</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Description</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                @forelse($products as $product)
                    <tr>
                        <td><input type="checkbox" name="ids[]" value="{{ $product->MaProduct }}" class="row-checkbox"></td>
                        <td>{{ $product->MaProduct }}</td>
                        <td>{{ $product->Name }}</td>
                        <td>{{ $product->category->Name }}</td>
                        <td>{{ number_format($product->Price) }}</td>
                        <td>{{ $product->Quantity }}</td>
                        <td>{{ Str::limit($product->Description, 50) }}</td>
                        <td>
                            <a href="{{ route('products.edit', $product) }}" class="btn btn-sm btn-primary">
                                <i class="bi bi-pencil"></i>
                            </a>
                            <form action="{{ route('products.destroy', $product) }}" method="POST" class="d-inline">
                                @csrf
                                @method('DELETE')
                                <button type="submit" class="btn btn-sm btn-danger" onclick="return confirm('Are you sure you want to delete this product?')">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </form>
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="8" class="text-center">No products found.</td>
                    </tr>
                @endforelse
            </tbody>
        </table>
    </div>
</form>

@section('scripts')
<script>
    document.getElementById('select-all').onclick = function() {
        let checkboxes = document.querySelectorAll('.row-checkbox');
        for (let checkbox of checkboxes) {
            checkbox.checked = this.checked;
        }
    };
</script>
@endsection 