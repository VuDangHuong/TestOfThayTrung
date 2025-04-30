@extends('layouts.app')

@section('title', 'Edit Product')

@section('content')
<div class="row mb-4">
    <div class="col-md-6">
        <h2>Edit Product</h2>
    </div>
    <div class="col-md-6 text-end">
        <a href="{{ route('products.index') }}" class="btn btn-secondary">
            <i class="bi bi-arrow-left"></i> Back to List
        </a>
    </div>
</div>

<div class="card">
    <div class="card-body">
        <form action="{{ route('products.update', $product) }}" method="POST">
            @csrf
            @method('PUT')
            <div class="mb-3">
                <label for="Name" class="form-label">Product Name</label>
                <input type="text" class="form-control @error('Name') is-invalid @enderror" id="Name" name="Name" value="{{ old('Name', $product->Name) }}" required>
                @error('Name')
                    <div class="invalid-feedback">{{ $message }}</div>
                @enderror
            </div>

            <div class="mb-3">
                <label for="MaCategory" class="form-label">Category</label>
                <select class="form-select @error('MaCategory') is-invalid @enderror" id="MaCategory" name="MaCategory" required>
                    <option value="">Select a category</option>
                    @foreach($categories as $category)
                        <option value="{{ $category->MaCategory }}" {{ old('MaCategory', $product->MaCategory) == $category->MaCategory ? 'selected' : '' }}>
                            {{ $category->Name }}
                        </option>
                    @endforeach
                </select>
                @error('MaCategory')
                    <div class="invalid-feedback">{{ $message }}</div>
                @enderror
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="Price" class="form-label">Price</label>
                        <input type="number" class="form-control @error('Price') is-invalid @enderror" id="Price" name="Price" value="{{ old('Price', $product->Price) }}" required min="0">
                        @error('Price')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="Quantity" class="form-label">Quantity</label>
                        <input type="number" class="form-control @error('Quantity') is-invalid @enderror" id="Quantity" name="Quantity" value="{{ old('Quantity', $product->Quantity) }}" required min="0">
                        @error('Quantity')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
            </div>

            <div class="mb-3">
                <label for="Description" class="form-label">Description</label>
                <textarea class="form-control @error('Description') is-invalid @enderror" id="Description" name="Description" rows="3">{{ old('Description', $product->Description) }}</textarea>
                @error('Description')
                    <div class="invalid-feedback">{{ $message }}</div>
                @enderror
            </div>

            <button type="submit" class="btn btn-primary">Update Product</button>
        </form>
    </div>
</div>
@endsection 