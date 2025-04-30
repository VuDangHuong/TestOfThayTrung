@extends('layouts.app')

@section('title', 'Categories')

@section('content')
    <div class="row mb-4">
        <div class="col-md-6">
            <h2>Categories</h2>
        </div>
        <div class="col-md-6 text-end">
            <a href="{{ route('categories.create') }}" class="btn btn-primary">
                <i class="bi bi-plus-circle"></i> Add New Category
            </a>
        </div>
    </div>

    @if(session('success'))
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            {{ session('success') }}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    @endif

    <form action="{{ route('categories.bulk-delete') }}" method="POST" id="bulk-delete-form">
        @csrf
        @method('DELETE')
        <div class="mb-2">
            <button type="submit" class="btn btn-danger btn-sm" onclick="return confirm('Bạn có chắc chắn muốn xóa các nhóm sản phẩm đã chọn?')">
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
                        <th>Description</th>
                        <th>Created At</th>
                        <th>Updated At</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($categories as $category)
                        <tr>
                            <td><input type="checkbox" name="ids[]" value="{{ $category->MaCategory }}" class="row-checkbox"></td>
                            <td>{{ $category->MaCategory }}</td>
                            <td>{{ $category->Name }}</td>
                            <td>{{ $category->Description }}</td>
                            <td>{{ \Carbon\Carbon::parse($category->CreatedAt)->format('Y-m-d H:i:s') }}</td>
                            <td>{{ \Carbon\Carbon::parse($category->UpdatedAt)->format('Y-m-d H:i:s') }}</td>
                            <td>
                                <a href="{{ route('categories.edit', $category) }}" class="btn btn-sm btn-primary">
                                    <i class="bi bi-pencil"></i>
                                </a>
                                <form action="{{ route('categories.destroy', $category) }}" method="POST" class="d-inline">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-sm btn-danger"
                                        onclick="return confirm('Are you sure you want to delete this category?')">
                                        <i class="bi bi-trash"></i>
                                    </button>
                                </form>
                            </td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="7" class="text-center">No categories found.</td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </form>
@endsection

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