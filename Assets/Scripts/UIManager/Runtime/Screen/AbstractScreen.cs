using System;
using UIManager.Runtime.Models;
using UnityEngine;

namespace UIManager.Runtime.Screen
{
    public abstract class AbstractScreen<TModel> : BaseScreen where TModel:IUiModel
    {
        public override Type ModelType => typeof(TModel);
        protected TModel _model;

        public override void Show()
        {
            _model.OnShow();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            _model.OnClose();
            gameObject.SetActive(false);
        }

        public override void Bind(object model)
        {
            if (model is TModel)
                Bind((TModel) model);
        }

        public void Bind(TModel model)
        {
            _model = model;
            OnBind(model);
        }

        protected abstract void OnBind(TModel model);
    }
}