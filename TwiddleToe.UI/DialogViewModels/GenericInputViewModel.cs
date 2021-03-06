﻿// <copyright file="GenericInputViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;
    using TwiddleToe.UI.Interfaces.Input.ViewModels;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.Utilities.Helpers;
    using TwiddleToe.Workers.Factories;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A generic imput view model.
    /// </summary>
    public class GenericInputViewModel : BaseViewModel
    {
        private readonly ViewModelFactory viewModelFactory;

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        private readonly IList<IGenericInput> sourceInput;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericInputViewModel" /> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelFactory">The view model factory.</param>
        /// <param name="title">The title.</param>
        /// <param name="inputs">The inputs.</param>
        /// <param name="workAreaProvider">The work area provider.</param>
        public GenericInputViewModel(
            ViewModelRegistry viewModelRegistry,
            StateProvider stateProvider,
            ViewModelFactory viewModelFactory,
            string title,
            IList<IGenericInput> inputs,
            WorkAreaProvider workAreaProvider)
            : base(viewModelRegistry, stateProvider)
        {
            this.viewModelFactory = viewModelFactory;
            this.Title = title;
            this.sourceInput = inputs;

            this.Inputs = new ObservableCollection<IInputViewModel>();

            this.Cancel = new RelayCommnand(() =>
            {
                this.UserAccepted = false;
                this.CloseView();
            });

            this.Ok = new RelayCommnand(
            () =>
            {
                this.UserAccepted = true;
                this.CloseView();
            },
            () =>
            {
                return this.Inputs.All(i => i.Validate());
            });

            var tabIndex = 0;

            foreach (var input in this.sourceInput)
            {
                tabIndex++;
                if (input is ITextInput textInput)
                {
                    var newInput = this.viewModelFactory.Create<TextInputViewModel>();
                    newInput.Label = textInput.Label;
                    newInput.Required = textInput.Required;
                    this.Inputs.Add(newInput);
                }
            }

            this.CalculatedHeight = 150 + (this.Inputs.Count * 53);

            var workArea = workAreaProvider.Get();

            this.CalculatedTop = Calculations.GetCenterCoordinate(workArea.Height, this.CalculatedHeight);
        }

        /// <summary>
        /// Gets or sets the calculated top.
        /// </summary>
        /// <value>
        /// The calculated top.
        /// </value>
        public double CalculatedTop { get; set; }

        /// <summary>
        /// Gets or sets the calculated left.
        /// </summary>
        /// <value>
        /// The calculated left.
        /// </value>
        public double Left { get; set; }

        /// <summary>
        /// Gets or sets the calculated height.
        /// </summary>
        /// <value>
        /// The calculated height.
        /// </value>
        public double CalculatedHeight { get; set; }

        /// <summary>
        /// Gets or sets the inputs.
        /// </summary>
        /// <value>
        /// The inputs.
        /// </value>
        public ObservableCollection<IInputViewModel> Inputs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GenericInputViewModel"/> is canceled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if canceled; otherwise, <c>false</c>.
        /// </value>
        public bool UserAccepted { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Ok command.
        /// </summary>
        /// <value>
        /// The ok.
        /// </value>
        public ICommand Ok { get; set; }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>
        /// The cancel.
        /// </value>
        public ICommand Cancel { get; set; }

        /// <summary>
        /// Focuses the first input.
        /// </summary>
        internal void FocusFirstInput()
        {
            foreach (var input in this.Inputs)
            {
                input.Focus = false;
            }

            this.Inputs.First().Focus = true;
        }

        /// <summary>
        /// Gets the data from the view models.
        /// </summary>
        /// <returns>An IList of data models.</returns>
        internal IList<IGenericInput> GetData()
        {
            var returnValue = new List<IGenericInput>();
            foreach (var input in this.Inputs)
            {
                returnValue.Add(input.GetData());
            }

            return returnValue;
        }
    }
}
