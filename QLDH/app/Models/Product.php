<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    protected $table = 'Product';
    protected $primaryKey = 'MaProduct';
    public $timestamps = false;

    protected $fillable = [
        'Name',
        'Price',
        'Quantity',
        'Description',
        'CreatedAt',
        'UpdatedAt',
        'MaCategory'
    ];

    public function category()
    {
        return $this->belongsTo(Category::class, 'MaCategory', 'MaCategory');
    }
} 