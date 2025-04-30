<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Category extends Model
{
    protected $table = 'Category';
    protected $primaryKey = 'MaCategory';
    public $timestamps = false;

    protected $fillable = [
        'Name',
        'Description',
        'CreatedAt',
        'UpdatedAt'
    ];

    public function products()
    {
        return $this->hasMany(Product::class, 'MaCategory', 'MaCategory');
    }
} 